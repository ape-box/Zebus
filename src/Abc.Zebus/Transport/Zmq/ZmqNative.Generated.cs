﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using System.Security;

namespace Abc.Zebus.Transport.Zmq
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    unsafe partial class ZmqNative
    {
        public static IntPtr ctx_new()
            => _impl.ctx_new();

        public static int ctx_term(IntPtr context)
            => _impl.ctx_term(context);

        public static IntPtr socket(IntPtr context, int type)
            => _impl.socket(context, type);

        public static int close(IntPtr socket)
            => _impl.close(socket);

        public static int getsockopt(IntPtr socket, int option_name, void* option_value, IntPtr* option_len)
            => _impl.getsockopt(socket, option_name, option_value, option_len);

        public static int setsockopt(IntPtr socket, int option_name, void* option_value, IntPtr option_len)
            => _impl.setsockopt(socket, option_name, option_value, option_len);

        public static int bind(IntPtr socket, string endpoint)
            => _impl.bind(socket, endpoint);

        public static int unbind(IntPtr socket, string endpoint)
            => _impl.unbind(socket, endpoint);

        public static int connect(IntPtr socket, string endpoint)
            => _impl.connect(socket, endpoint);

        public static int disconnect(IntPtr socket, string endpoint)
            => _impl.disconnect(socket, endpoint);

        public static int send(IntPtr socket, void* buf, IntPtr len, int flags)
            => _impl.send(socket, buf, len, flags);

        public static int msg_init(ZmqMessage* msg)
            => _impl.msg_init(msg);

        public static int msg_recv(ZmqMessage* msg, IntPtr socket, int flags)
            => _impl.msg_recv(msg, socket, flags);

        public static int msg_close(ZmqMessage* msg)
            => _impl.msg_close(msg);

        public static void* msg_data(ZmqMessage* msg)
            => _impl.msg_data(msg);

        public static IntPtr msg_size(ZmqMessage* msg)
            => _impl.msg_size(msg);

        public static ZmqErrorCode errno()
            => _impl.errno();

        public static byte* strerror(int errnum)
            => _impl.strerror(errnum);

        public static void version(int* major, int* minor, int* patch)
            => _impl.version(major, minor, patch);


        private abstract class LibImpl
        {
            public abstract IntPtr ctx_new();
            public abstract int ctx_term(IntPtr context);
            public abstract IntPtr socket(IntPtr context, int type);
            public abstract int close(IntPtr socket);
            public abstract int getsockopt(IntPtr socket, int option_name, void* option_value, IntPtr* option_len);
            public abstract int setsockopt(IntPtr socket, int option_name, void* option_value, IntPtr option_len);
            public abstract int bind(IntPtr socket, string endpoint);
            public abstract int unbind(IntPtr socket, string endpoint);
            public abstract int connect(IntPtr socket, string endpoint);
            public abstract int disconnect(IntPtr socket, string endpoint);
            public abstract int send(IntPtr socket, void* buf, IntPtr len, int flags);
            public abstract int msg_init(ZmqMessage* msg);
            public abstract int msg_recv(ZmqMessage* msg, IntPtr socket, int flags);
            public abstract int msg_close(ZmqMessage* msg);
            public abstract void* msg_data(ZmqMessage* msg);
            public abstract IntPtr msg_size(ZmqMessage* msg);
            public abstract ZmqErrorCode errno();
            public abstract byte* strerror(int errnum);
            public abstract void version(int* major, int* minor, int* patch);
        }

        [SuppressUnmanagedCodeSecurity]
        private class WinImpl : LibImpl
        {
            public override IntPtr ctx_new()
                => zmq_ctx_new();

            [DllImport("Abc.Zebus.libzmq.dll", CallingConvention = CallingConvention.Cdecl)]
            private static extern IntPtr zmq_ctx_new();

            public override int ctx_term(IntPtr context)
                => zmq_ctx_term(context);

            [DllImport("Abc.Zebus.libzmq.dll", CallingConvention = CallingConvention.Cdecl)]
            private static extern int zmq_ctx_term(IntPtr context);

            public override IntPtr socket(IntPtr context, int type)
                => zmq_socket(context, type);

            [DllImport("Abc.Zebus.libzmq.dll", CallingConvention = CallingConvention.Cdecl)]
            private static extern IntPtr zmq_socket(IntPtr context, int type);

            public override int close(IntPtr socket)
                => zmq_close(socket);

            [DllImport("Abc.Zebus.libzmq.dll", CallingConvention = CallingConvention.Cdecl)]
            private static extern int zmq_close(IntPtr socket);

            public override int getsockopt(IntPtr socket, int option_name, void* option_value, IntPtr* option_len)
                => zmq_getsockopt(socket, option_name, option_value, option_len);

            [DllImport("Abc.Zebus.libzmq.dll", CallingConvention = CallingConvention.Cdecl)]
            private static extern int zmq_getsockopt(IntPtr socket, int option_name, void* option_value, IntPtr* option_len);

            public override int setsockopt(IntPtr socket, int option_name, void* option_value, IntPtr option_len)
                => zmq_setsockopt(socket, option_name, option_value, option_len);

            [DllImport("Abc.Zebus.libzmq.dll", CallingConvention = CallingConvention.Cdecl)]
            private static extern int zmq_setsockopt(IntPtr socket, int option_name, void* option_value, IntPtr option_len);

            public override int bind(IntPtr socket, string endpoint)
                => zmq_bind(socket, endpoint);

            [DllImport("Abc.Zebus.libzmq.dll", CallingConvention = CallingConvention.Cdecl)]
            private static extern int zmq_bind(IntPtr socket, [In, MarshalAs(UnmanagedType.LPStr)] string endpoint);

            public override int unbind(IntPtr socket, string endpoint)
                => zmq_unbind(socket, endpoint);

            [DllImport("Abc.Zebus.libzmq.dll", CallingConvention = CallingConvention.Cdecl)]
            private static extern int zmq_unbind(IntPtr socket, [In, MarshalAs(UnmanagedType.LPStr)] string endpoint);

            public override int connect(IntPtr socket, string endpoint)
                => zmq_connect(socket, endpoint);

            [DllImport("Abc.Zebus.libzmq.dll", CallingConvention = CallingConvention.Cdecl)]
            private static extern int zmq_connect(IntPtr socket, [In, MarshalAs(UnmanagedType.LPStr)] string endpoint);

            public override int disconnect(IntPtr socket, string endpoint)
                => zmq_disconnect(socket, endpoint);

            [DllImport("Abc.Zebus.libzmq.dll", CallingConvention = CallingConvention.Cdecl)]
            private static extern int zmq_disconnect(IntPtr socket, [In, MarshalAs(UnmanagedType.LPStr)] string endpoint);

            public override int send(IntPtr socket, void* buf, IntPtr len, int flags)
                => zmq_send(socket, buf, len, flags);

            [DllImport("Abc.Zebus.libzmq.dll", CallingConvention = CallingConvention.Cdecl)]
            private static extern int zmq_send(IntPtr socket, void* buf, IntPtr len, int flags);

            public override int msg_init(ZmqMessage* msg)
                => zmq_msg_init(msg);

            [DllImport("Abc.Zebus.libzmq.dll", CallingConvention = CallingConvention.Cdecl)]
            private static extern int zmq_msg_init(ZmqMessage* msg);

            public override int msg_recv(ZmqMessage* msg, IntPtr socket, int flags)
                => zmq_msg_recv(msg, socket, flags);

            [DllImport("Abc.Zebus.libzmq.dll", CallingConvention = CallingConvention.Cdecl)]
            private static extern int zmq_msg_recv(ZmqMessage* msg, IntPtr socket, int flags);

            public override int msg_close(ZmqMessage* msg)
                => zmq_msg_close(msg);

            [DllImport("Abc.Zebus.libzmq.dll", CallingConvention = CallingConvention.Cdecl)]
            private static extern int zmq_msg_close(ZmqMessage* msg);

            public override void* msg_data(ZmqMessage* msg)
                => zmq_msg_data(msg);

            [DllImport("Abc.Zebus.libzmq.dll", CallingConvention = CallingConvention.Cdecl)]
            private static extern void* zmq_msg_data(ZmqMessage* msg);

            public override IntPtr msg_size(ZmqMessage* msg)
                => zmq_msg_size(msg);

            [DllImport("Abc.Zebus.libzmq.dll", CallingConvention = CallingConvention.Cdecl)]
            private static extern IntPtr zmq_msg_size(ZmqMessage* msg);

            public override ZmqErrorCode errno()
                => zmq_errno();

            [DllImport("Abc.Zebus.libzmq.dll", CallingConvention = CallingConvention.Cdecl)]
            private static extern ZmqErrorCode zmq_errno();

            public override byte* strerror(int errnum)
                => zmq_strerror(errnum);

            [DllImport("Abc.Zebus.libzmq.dll", CallingConvention = CallingConvention.Cdecl)]
            private static extern byte* zmq_strerror(int errnum);

            public override void version(int* major, int* minor, int* patch)
                => zmq_version(major, minor, patch);

            [DllImport("Abc.Zebus.libzmq.dll", CallingConvention = CallingConvention.Cdecl)]
            private static extern void zmq_version(int* major, int* minor, int* patch);

        }

        [SuppressUnmanagedCodeSecurity]
        private class Win32Impl : LibImpl
        {
            public override IntPtr ctx_new()
                => zmq_ctx_new();

            [DllImport("Abc.Zebus.libzmq.x86.dll", CallingConvention = CallingConvention.Cdecl)]
            private static extern IntPtr zmq_ctx_new();

            public override int ctx_term(IntPtr context)
                => zmq_ctx_term(context);

            [DllImport("Abc.Zebus.libzmq.x86.dll", CallingConvention = CallingConvention.Cdecl)]
            private static extern int zmq_ctx_term(IntPtr context);

            public override IntPtr socket(IntPtr context, int type)
                => zmq_socket(context, type);

            [DllImport("Abc.Zebus.libzmq.x86.dll", CallingConvention = CallingConvention.Cdecl)]
            private static extern IntPtr zmq_socket(IntPtr context, int type);

            public override int close(IntPtr socket)
                => zmq_close(socket);

            [DllImport("Abc.Zebus.libzmq.x86.dll", CallingConvention = CallingConvention.Cdecl)]
            private static extern int zmq_close(IntPtr socket);

            public override int getsockopt(IntPtr socket, int option_name, void* option_value, IntPtr* option_len)
                => zmq_getsockopt(socket, option_name, option_value, option_len);

            [DllImport("Abc.Zebus.libzmq.x86.dll", CallingConvention = CallingConvention.Cdecl)]
            private static extern int zmq_getsockopt(IntPtr socket, int option_name, void* option_value, IntPtr* option_len);

            public override int setsockopt(IntPtr socket, int option_name, void* option_value, IntPtr option_len)
                => zmq_setsockopt(socket, option_name, option_value, option_len);

            [DllImport("Abc.Zebus.libzmq.x86.dll", CallingConvention = CallingConvention.Cdecl)]
            private static extern int zmq_setsockopt(IntPtr socket, int option_name, void* option_value, IntPtr option_len);

            public override int bind(IntPtr socket, string endpoint)
                => zmq_bind(socket, endpoint);

            [DllImport("Abc.Zebus.libzmq.x86.dll", CallingConvention = CallingConvention.Cdecl)]
            private static extern int zmq_bind(IntPtr socket, [In, MarshalAs(UnmanagedType.LPStr)] string endpoint);

            public override int unbind(IntPtr socket, string endpoint)
                => zmq_unbind(socket, endpoint);

            [DllImport("Abc.Zebus.libzmq.x86.dll", CallingConvention = CallingConvention.Cdecl)]
            private static extern int zmq_unbind(IntPtr socket, [In, MarshalAs(UnmanagedType.LPStr)] string endpoint);

            public override int connect(IntPtr socket, string endpoint)
                => zmq_connect(socket, endpoint);

            [DllImport("Abc.Zebus.libzmq.x86.dll", CallingConvention = CallingConvention.Cdecl)]
            private static extern int zmq_connect(IntPtr socket, [In, MarshalAs(UnmanagedType.LPStr)] string endpoint);

            public override int disconnect(IntPtr socket, string endpoint)
                => zmq_disconnect(socket, endpoint);

            [DllImport("Abc.Zebus.libzmq.x86.dll", CallingConvention = CallingConvention.Cdecl)]
            private static extern int zmq_disconnect(IntPtr socket, [In, MarshalAs(UnmanagedType.LPStr)] string endpoint);

            public override int send(IntPtr socket, void* buf, IntPtr len, int flags)
                => zmq_send(socket, buf, len, flags);

            [DllImport("Abc.Zebus.libzmq.x86.dll", CallingConvention = CallingConvention.Cdecl)]
            private static extern int zmq_send(IntPtr socket, void* buf, IntPtr len, int flags);

            public override int msg_init(ZmqMessage* msg)
                => zmq_msg_init(msg);

            [DllImport("Abc.Zebus.libzmq.x86.dll", CallingConvention = CallingConvention.Cdecl)]
            private static extern int zmq_msg_init(ZmqMessage* msg);

            public override int msg_recv(ZmqMessage* msg, IntPtr socket, int flags)
                => zmq_msg_recv(msg, socket, flags);

            [DllImport("Abc.Zebus.libzmq.x86.dll", CallingConvention = CallingConvention.Cdecl)]
            private static extern int zmq_msg_recv(ZmqMessage* msg, IntPtr socket, int flags);

            public override int msg_close(ZmqMessage* msg)
                => zmq_msg_close(msg);

            [DllImport("Abc.Zebus.libzmq.x86.dll", CallingConvention = CallingConvention.Cdecl)]
            private static extern int zmq_msg_close(ZmqMessage* msg);

            public override void* msg_data(ZmqMessage* msg)
                => zmq_msg_data(msg);

            [DllImport("Abc.Zebus.libzmq.x86.dll", CallingConvention = CallingConvention.Cdecl)]
            private static extern void* zmq_msg_data(ZmqMessage* msg);

            public override IntPtr msg_size(ZmqMessage* msg)
                => zmq_msg_size(msg);

            [DllImport("Abc.Zebus.libzmq.x86.dll", CallingConvention = CallingConvention.Cdecl)]
            private static extern IntPtr zmq_msg_size(ZmqMessage* msg);

            public override ZmqErrorCode errno()
                => zmq_errno();

            [DllImport("Abc.Zebus.libzmq.x86.dll", CallingConvention = CallingConvention.Cdecl)]
            private static extern ZmqErrorCode zmq_errno();

            public override byte* strerror(int errnum)
                => zmq_strerror(errnum);

            [DllImport("Abc.Zebus.libzmq.x86.dll", CallingConvention = CallingConvention.Cdecl)]
            private static extern byte* zmq_strerror(int errnum);

            public override void version(int* major, int* minor, int* patch)
                => zmq_version(major, minor, patch);

            [DllImport("Abc.Zebus.libzmq.x86.dll", CallingConvention = CallingConvention.Cdecl)]
            private static extern void zmq_version(int* major, int* minor, int* patch);

        }

        [SuppressUnmanagedCodeSecurity]
        private class Win64Impl : LibImpl
        {
            public override IntPtr ctx_new()
                => zmq_ctx_new();

            [DllImport("Abc.Zebus.libzmq.x64.dll", CallingConvention = CallingConvention.Cdecl)]
            private static extern IntPtr zmq_ctx_new();

            public override int ctx_term(IntPtr context)
                => zmq_ctx_term(context);

            [DllImport("Abc.Zebus.libzmq.x64.dll", CallingConvention = CallingConvention.Cdecl)]
            private static extern int zmq_ctx_term(IntPtr context);

            public override IntPtr socket(IntPtr context, int type)
                => zmq_socket(context, type);

            [DllImport("Abc.Zebus.libzmq.x64.dll", CallingConvention = CallingConvention.Cdecl)]
            private static extern IntPtr zmq_socket(IntPtr context, int type);

            public override int close(IntPtr socket)
                => zmq_close(socket);

            [DllImport("Abc.Zebus.libzmq.x64.dll", CallingConvention = CallingConvention.Cdecl)]
            private static extern int zmq_close(IntPtr socket);

            public override int getsockopt(IntPtr socket, int option_name, void* option_value, IntPtr* option_len)
                => zmq_getsockopt(socket, option_name, option_value, option_len);

            [DllImport("Abc.Zebus.libzmq.x64.dll", CallingConvention = CallingConvention.Cdecl)]
            private static extern int zmq_getsockopt(IntPtr socket, int option_name, void* option_value, IntPtr* option_len);

            public override int setsockopt(IntPtr socket, int option_name, void* option_value, IntPtr option_len)
                => zmq_setsockopt(socket, option_name, option_value, option_len);

            [DllImport("Abc.Zebus.libzmq.x64.dll", CallingConvention = CallingConvention.Cdecl)]
            private static extern int zmq_setsockopt(IntPtr socket, int option_name, void* option_value, IntPtr option_len);

            public override int bind(IntPtr socket, string endpoint)
                => zmq_bind(socket, endpoint);

            [DllImport("Abc.Zebus.libzmq.x64.dll", CallingConvention = CallingConvention.Cdecl)]
            private static extern int zmq_bind(IntPtr socket, [In, MarshalAs(UnmanagedType.LPStr)] string endpoint);

            public override int unbind(IntPtr socket, string endpoint)
                => zmq_unbind(socket, endpoint);

            [DllImport("Abc.Zebus.libzmq.x64.dll", CallingConvention = CallingConvention.Cdecl)]
            private static extern int zmq_unbind(IntPtr socket, [In, MarshalAs(UnmanagedType.LPStr)] string endpoint);

            public override int connect(IntPtr socket, string endpoint)
                => zmq_connect(socket, endpoint);

            [DllImport("Abc.Zebus.libzmq.x64.dll", CallingConvention = CallingConvention.Cdecl)]
            private static extern int zmq_connect(IntPtr socket, [In, MarshalAs(UnmanagedType.LPStr)] string endpoint);

            public override int disconnect(IntPtr socket, string endpoint)
                => zmq_disconnect(socket, endpoint);

            [DllImport("Abc.Zebus.libzmq.x64.dll", CallingConvention = CallingConvention.Cdecl)]
            private static extern int zmq_disconnect(IntPtr socket, [In, MarshalAs(UnmanagedType.LPStr)] string endpoint);

            public override int send(IntPtr socket, void* buf, IntPtr len, int flags)
                => zmq_send(socket, buf, len, flags);

            [DllImport("Abc.Zebus.libzmq.x64.dll", CallingConvention = CallingConvention.Cdecl)]
            private static extern int zmq_send(IntPtr socket, void* buf, IntPtr len, int flags);

            public override int msg_init(ZmqMessage* msg)
                => zmq_msg_init(msg);

            [DllImport("Abc.Zebus.libzmq.x64.dll", CallingConvention = CallingConvention.Cdecl)]
            private static extern int zmq_msg_init(ZmqMessage* msg);

            public override int msg_recv(ZmqMessage* msg, IntPtr socket, int flags)
                => zmq_msg_recv(msg, socket, flags);

            [DllImport("Abc.Zebus.libzmq.x64.dll", CallingConvention = CallingConvention.Cdecl)]
            private static extern int zmq_msg_recv(ZmqMessage* msg, IntPtr socket, int flags);

            public override int msg_close(ZmqMessage* msg)
                => zmq_msg_close(msg);

            [DllImport("Abc.Zebus.libzmq.x64.dll", CallingConvention = CallingConvention.Cdecl)]
            private static extern int zmq_msg_close(ZmqMessage* msg);

            public override void* msg_data(ZmqMessage* msg)
                => zmq_msg_data(msg);

            [DllImport("Abc.Zebus.libzmq.x64.dll", CallingConvention = CallingConvention.Cdecl)]
            private static extern void* zmq_msg_data(ZmqMessage* msg);

            public override IntPtr msg_size(ZmqMessage* msg)
                => zmq_msg_size(msg);

            [DllImport("Abc.Zebus.libzmq.x64.dll", CallingConvention = CallingConvention.Cdecl)]
            private static extern IntPtr zmq_msg_size(ZmqMessage* msg);

            public override ZmqErrorCode errno()
                => zmq_errno();

            [DllImport("Abc.Zebus.libzmq.x64.dll", CallingConvention = CallingConvention.Cdecl)]
            private static extern ZmqErrorCode zmq_errno();

            public override byte* strerror(int errnum)
                => zmq_strerror(errnum);

            [DllImport("Abc.Zebus.libzmq.x64.dll", CallingConvention = CallingConvention.Cdecl)]
            private static extern byte* zmq_strerror(int errnum);

            public override void version(int* major, int* minor, int* patch)
                => zmq_version(major, minor, patch);

            [DllImport("Abc.Zebus.libzmq.x64.dll", CallingConvention = CallingConvention.Cdecl)]
            private static extern void zmq_version(int* major, int* minor, int* patch);

        }

        [SuppressUnmanagedCodeSecurity]
        private class LinuxImpl : LibImpl
        {
            public override IntPtr ctx_new()
                => zmq_ctx_new();

            [DllImport("Abc.Zebus.libzmq.so", CallingConvention = CallingConvention.Cdecl)]
            private static extern IntPtr zmq_ctx_new();

            public override int ctx_term(IntPtr context)
                => zmq_ctx_term(context);

            [DllImport("Abc.Zebus.libzmq.so", CallingConvention = CallingConvention.Cdecl)]
            private static extern int zmq_ctx_term(IntPtr context);

            public override IntPtr socket(IntPtr context, int type)
                => zmq_socket(context, type);

            [DllImport("Abc.Zebus.libzmq.so", CallingConvention = CallingConvention.Cdecl)]
            private static extern IntPtr zmq_socket(IntPtr context, int type);

            public override int close(IntPtr socket)
                => zmq_close(socket);

            [DllImport("Abc.Zebus.libzmq.so", CallingConvention = CallingConvention.Cdecl)]
            private static extern int zmq_close(IntPtr socket);

            public override int getsockopt(IntPtr socket, int option_name, void* option_value, IntPtr* option_len)
                => zmq_getsockopt(socket, option_name, option_value, option_len);

            [DllImport("Abc.Zebus.libzmq.so", CallingConvention = CallingConvention.Cdecl)]
            private static extern int zmq_getsockopt(IntPtr socket, int option_name, void* option_value, IntPtr* option_len);

            public override int setsockopt(IntPtr socket, int option_name, void* option_value, IntPtr option_len)
                => zmq_setsockopt(socket, option_name, option_value, option_len);

            [DllImport("Abc.Zebus.libzmq.so", CallingConvention = CallingConvention.Cdecl)]
            private static extern int zmq_setsockopt(IntPtr socket, int option_name, void* option_value, IntPtr option_len);

            public override int bind(IntPtr socket, string endpoint)
                => zmq_bind(socket, endpoint);

            [DllImport("Abc.Zebus.libzmq.so", CallingConvention = CallingConvention.Cdecl)]
            private static extern int zmq_bind(IntPtr socket, [In, MarshalAs(UnmanagedType.LPStr)] string endpoint);

            public override int unbind(IntPtr socket, string endpoint)
                => zmq_unbind(socket, endpoint);

            [DllImport("Abc.Zebus.libzmq.so", CallingConvention = CallingConvention.Cdecl)]
            private static extern int zmq_unbind(IntPtr socket, [In, MarshalAs(UnmanagedType.LPStr)] string endpoint);

            public override int connect(IntPtr socket, string endpoint)
                => zmq_connect(socket, endpoint);

            [DllImport("Abc.Zebus.libzmq.so", CallingConvention = CallingConvention.Cdecl)]
            private static extern int zmq_connect(IntPtr socket, [In, MarshalAs(UnmanagedType.LPStr)] string endpoint);

            public override int disconnect(IntPtr socket, string endpoint)
                => zmq_disconnect(socket, endpoint);

            [DllImport("Abc.Zebus.libzmq.so", CallingConvention = CallingConvention.Cdecl)]
            private static extern int zmq_disconnect(IntPtr socket, [In, MarshalAs(UnmanagedType.LPStr)] string endpoint);

            public override int send(IntPtr socket, void* buf, IntPtr len, int flags)
                => zmq_send(socket, buf, len, flags);

            [DllImport("Abc.Zebus.libzmq.so", CallingConvention = CallingConvention.Cdecl)]
            private static extern int zmq_send(IntPtr socket, void* buf, IntPtr len, int flags);

            public override int msg_init(ZmqMessage* msg)
                => zmq_msg_init(msg);

            [DllImport("Abc.Zebus.libzmq.so", CallingConvention = CallingConvention.Cdecl)]
            private static extern int zmq_msg_init(ZmqMessage* msg);

            public override int msg_recv(ZmqMessage* msg, IntPtr socket, int flags)
                => zmq_msg_recv(msg, socket, flags);

            [DllImport("Abc.Zebus.libzmq.so", CallingConvention = CallingConvention.Cdecl)]
            private static extern int zmq_msg_recv(ZmqMessage* msg, IntPtr socket, int flags);

            public override int msg_close(ZmqMessage* msg)
                => zmq_msg_close(msg);

            [DllImport("Abc.Zebus.libzmq.so", CallingConvention = CallingConvention.Cdecl)]
            private static extern int zmq_msg_close(ZmqMessage* msg);

            public override void* msg_data(ZmqMessage* msg)
                => zmq_msg_data(msg);

            [DllImport("Abc.Zebus.libzmq.so", CallingConvention = CallingConvention.Cdecl)]
            private static extern void* zmq_msg_data(ZmqMessage* msg);

            public override IntPtr msg_size(ZmqMessage* msg)
                => zmq_msg_size(msg);

            [DllImport("Abc.Zebus.libzmq.so", CallingConvention = CallingConvention.Cdecl)]
            private static extern IntPtr zmq_msg_size(ZmqMessage* msg);

            public override ZmqErrorCode errno()
                => zmq_errno();

            [DllImport("Abc.Zebus.libzmq.so", CallingConvention = CallingConvention.Cdecl)]
            private static extern ZmqErrorCode zmq_errno();

            public override byte* strerror(int errnum)
                => zmq_strerror(errnum);

            [DllImport("Abc.Zebus.libzmq.so", CallingConvention = CallingConvention.Cdecl)]
            private static extern byte* zmq_strerror(int errnum);

            public override void version(int* major, int* minor, int* patch)
                => zmq_version(major, minor, patch);

            [DllImport("Abc.Zebus.libzmq.so", CallingConvention = CallingConvention.Cdecl)]
            private static extern void zmq_version(int* major, int* minor, int* patch);

        }

    }
}
