using System;
using System.Collections.Concurrent;
using Abc.Zebus.Util;

namespace Abc.Zebus
{
    internal static class MessageTypeDescriptorCache
    {
        private static readonly ConcurrentDictionary<string, MessageTypeDescriptor> _descriptorsByFullName = new ConcurrentDictionary<string, MessageTypeDescriptor>();
        private static readonly ConcurrentDictionary<Type, MessageTypeDescriptor> _descriptorsByType = new ConcurrentDictionary<Type, MessageTypeDescriptor>();

        private static readonly Func<string?, MessageTypeDescriptor> _loadDescriptorFromName = LoadMessageTypeDescriptor;
        private static readonly Func<Type?, MessageTypeDescriptor> _loadDescriptorFromType = LoadMessageTypeDescriptor;

        internal static MessageTypeDescriptor GetMessageTypeDescriptor(string? fullName)
        {
            if (fullName == null)
                return MessageTypeDescriptor.Null;

            return _descriptorsByFullName.GetOrAdd(fullName, _loadDescriptorFromName);
        }

        private static MessageTypeDescriptor LoadMessageTypeDescriptor(string? fullName)
        {
            return MessageTypeDescriptor.Load(fullName);
        }

        internal static MessageTypeDescriptor GetMessageTypeDescriptor(Type? messageType)
        {
            if (messageType == null)
                return MessageTypeDescriptor.Null;

            return _descriptorsByType.GetOrAdd(messageType, _loadDescriptorFromType);
        }

        private static MessageTypeDescriptor LoadMessageTypeDescriptor(Type? messageType)
        {
            if (messageType == null)
                return MessageTypeDescriptor.Null;

            var fullName = TypeUtil.GetFullnameWithNoAssemblyOrVersion(messageType);
            return GetMessageTypeDescriptor(fullName);
        }
    }
}