﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Reflection;
using System.Text.RegularExpressions;
using Abc.Zebus.Directory;
using Abc.Zebus.Routing;
using Abc.Zebus.Util;
using JetBrains.Annotations;
using ProtoBuf;

namespace Abc.Zebus
{
    [ProtoContract]
    public class Subscription : IEquatable<Subscription>
    {
        private static readonly MethodInfo _wildCardTokenMethod = typeof(Builder).GetMethod("Any");
        private int _computedHashCode;

        [ProtoMember(1, IsRequired = true)]
        public readonly MessageTypeId MessageTypeId;

        [ProtoMember(2, IsRequired = true)]
        public readonly BindingKey BindingKey;

        public Subscription(MessageTypeId messageTypeId)
            : this(messageTypeId, BindingKey.Empty)
        {
        }

        public Subscription(MessageTypeId messageTypeId, BindingKey bindingKey)
        {
            MessageTypeId = messageTypeId;
            BindingKey = bindingKey;
        }

        [UsedImplicitly]
        private Subscription()
        {
        }

        public bool IsMatchingAllMessages => BindingKey.IsEmpty;

        public bool Matches(MessageBinding messageBinding)
        {
            return messageBinding.MessageTypeId == MessageTypeId && Matches(messageBinding.RoutingKey);
        }

        public bool Matches(BindingKey routingKey)
        {
            if (BindingKey.IsEmpty)
                return true;

            for (var i = 0; i < routingKey.PartCount; i++)
            {
                var evaluatedPart = BindingKey.GetPart(i);
                if (evaluatedPart == "#")
                    return true;

                if (evaluatedPart != "*" && routingKey.GetPart(i) != evaluatedPart)
                    return false;
            }

            return routingKey.PartCount == BindingKey.PartCount;
        }

        public bool Equals(Subscription other)
        {
            if (other == null)
                return false;

            return MessageTypeId.Equals(other.MessageTypeId) && BindingKey.Equals(other.BindingKey);
        }

        public override bool Equals(object obj) => Equals(obj as Subscription);

        public override int GetHashCode()
        {
            unchecked
            {
                // ReSharper disable NonReadonlyMemberInGetHashCode
                if (_computedHashCode == 0)
                    _computedHashCode = (MessageTypeId.GetHashCode() * 397) ^ BindingKey.GetHashCode();

                return _computedHashCode;
                // ReSharper restore NonReadonlyMemberInGetHashCode
            }
        }

        public override string ToString()
        {
            if (BindingKey.IsEmpty)
                return MessageTypeId.ToString();

            return $"{MessageTypeId} ({BindingKey})";
        }

        public static Subscription ByExample<TMessage>(Expression<Func<Builder, TMessage>> factory) where TMessage : IMessage
        {
            if (factory.Body.NodeType != ExpressionType.New)
                throw new ArgumentException();

            var parameterValues = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

            using (CultureScope.Invariant())
            {
                var newExpression = (NewExpression)factory.Body;
                var parameters = newExpression.Constructor.GetParameters();

                for (var argumentIndex = 0; argumentIndex < newExpression.Arguments.Count; ++argumentIndex)
                {
                    var argumentExpression = newExpression.Arguments[argumentIndex];
                    var parameterName = parameters[argumentIndex].Name;
                    var parameterValue = GetExpressionValue(argumentExpression);

                    if (parameterValue != null)
                        parameterValues[parameterName] = parameterValue.ToString();
                }
            }

            return new Subscription(MessageUtil.TypeId<TMessage>(), BindingKey.Create(typeof(TMessage), parameterValues));
        }

        private static object GetExpressionValue(Expression expression)
        {
            if (expression.NodeType != ExpressionType.Call)
                return Expression.Lambda(expression).Compile().DynamicInvoke();

            var methodCallExpression = (MethodCallExpression)expression;
            if (methodCallExpression.Method.IsGenericMethod && methodCallExpression.Method.GetGenericMethodDefinition() == _wildCardTokenMethod)
                return null;

            return Expression.Lambda(expression).Compile().DynamicInvoke();
        }

        public static Subscription Any<TMessage>() where TMessage : IMessage
            => new Subscription(MessageUtil.TypeId<TMessage>());

        public static Subscription Matching<TMessage>(Expression<Func<TMessage, bool>> predicate) where TMessage : IMessage
        {
            var fieldValues = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

            using (CultureScope.Invariant())
            {
                var current = predicate.Body;
                while (current.NodeType == ExpressionType.And || current.NodeType == ExpressionType.AndAlso)
                {
                    var binaryExpression = (BinaryExpression)current;
                    AddFieldValue<TMessage>(fieldValues, binaryExpression.Right);
                    current = binaryExpression.Left;
                }

                AddFieldValue<TMessage>(fieldValues, current);
            }

            return new Subscription(MessageUtil.TypeId<TMessage>(), BindingKey.Create(typeof(TMessage), fieldValues));
        }

        private static void AddFieldValue<TMessage>(Dictionary<string, string> fieldValues, Expression expression)
        {
            var binaryExpression = expression as BinaryExpression;
            if (binaryExpression != null)
            {
                AddFieldValueFromBinaryExpression<TMessage>(fieldValues, binaryExpression);
                return;
            }

            var unaryExpression = expression as UnaryExpression;
            if (unaryExpression != null)
            {
                AddFieldValueFromUnaryExpression<TMessage>(fieldValues, unaryExpression);
                return;
            }

            var memberExpression = expression as MemberExpression;
            if (memberExpression != null)
            {
                AddFieldValueFromMemberExpression<TMessage>(fieldValues, memberExpression);
                return;
            }

            throw CreateArgumentException(expression);
        }

        private static void AddFieldValueFromUnaryExpression<T>(Dictionary<string, string> fieldValues, UnaryExpression unaryExpression)
        {
            if (unaryExpression.Type != typeof(bool))
                throw CreateArgumentException(unaryExpression);

            if (unaryExpression.NodeType != ExpressionType.Not)
                throw CreateArgumentException(unaryExpression);

            var currentFieldValue = false;

            while (unaryExpression.Operand is UnaryExpression)
            {
                currentFieldValue = !currentFieldValue;
                unaryExpression = (UnaryExpression)unaryExpression.Operand;
            }

            var memberExpression = unaryExpression.Operand as MemberExpression;
            if (memberExpression == null)
                throw CreateArgumentException(unaryExpression);

            AddFieldValueFromMemberExpression<T>(fieldValues, memberExpression, currentFieldValue);
        }

        private static void AddFieldValueFromMemberExpression<TMessage>(Dictionary<string, string> fieldValues, MemberExpression memberExpression, bool fieldValue = true)
        {
            if (!IsMessageMemberExpression<TMessage>(memberExpression))
                throw CreateArgumentException(memberExpression);

            if (memberExpression.Type != typeof(bool))
                throw CreateArgumentException(memberExpression);

            fieldValues.Add(memberExpression.Member.Name, fieldValue.ToString());
        }

        private static void AddFieldValueFromBinaryExpression<TMessage>(Dictionary<string, string> fieldValues, BinaryExpression binaryExpression)
        {
            MemberExpression memberExpression;
            Expression memberValueExpression;

            if (TryGetMessageMemberExpression<TMessage>(binaryExpression.Right, out memberExpression))
            {
                memberValueExpression = binaryExpression.Left;
            }
            else if (TryGetMessageMemberExpression<TMessage>(binaryExpression.Left, out memberExpression))
            {
                memberValueExpression = binaryExpression.Right;
            }
            else
            {
                throw CreateArgumentException(binaryExpression);
            }

            var memberName = memberExpression.Member.Name;
            var memberValue = Expression.Lambda(memberValueExpression).Compile().DynamicInvoke();
            if (memberValue == null)
                return;

            var valueAsText = memberExpression.Type.IsEnum ? Enum.GetName(memberExpression.Type, memberValue) : memberValue.ToString();
            fieldValues.Add(memberName, valueAsText);
        }

        private static bool TryGetMessageMemberExpression<TMessage>(Expression expression, out MemberExpression memberExpression)
        {
            memberExpression = expression as MemberExpression;
            if (memberExpression != null)
                return IsMessageMemberExpression<TMessage>(memberExpression);

            var unaryExpression = expression as UnaryExpression;
            if (unaryExpression == null)
                return false;

            memberExpression = unaryExpression.Operand as MemberExpression;
            if (memberExpression == null)
                return false;

            return IsMessageMemberExpression<TMessage>(memberExpression);
        }

        private static bool IsMessageMemberExpression<TMessage>(MemberExpression memberExpression)
        {
            var parameterExpression = memberExpression.Expression as ParameterExpression;
            if (parameterExpression != null)
                return parameterExpression.Type == typeof(TMessage);

            var convertExpression = memberExpression.Expression as UnaryExpression;
            if (convertExpression == null || convertExpression.NodeType != ExpressionType.Convert)
                return false;

            var typedParameterExpression = convertExpression.Operand as ParameterExpression;
            if (typedParameterExpression == null)
                return false;

            return typedParameterExpression.Type.IsAssignableFrom(typeof(TMessage));
        }

        private static ArgumentException CreateArgumentException(Expression expression)
        {
            return new ArgumentException("Invalid message predicate: " + expression);
        }

        [EditorBrowsable(EditorBrowsableState.Never), UsedImplicitly]
        public class Builder
        {
            public T Any<T>() => default(T);
        }
    }
}
