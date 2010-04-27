using System;
using System.Reflection;

namespace Eisk.TestHelpers
{

    /// <summary>
    /// Design and Architecture: Mohammad Ashraful Alam [http://www.ashraful.net]
    /// </summary>
    public sealed class ReflectorHelper
    {
        ReflectorHelper() { }

        private const BindingFlags CommonFlags = BindingFlags.Public | BindingFlags.NonPublic;

        /// <summary>
        /// 
        /// </summary>
        public static object CreateInstance(Type type, params object[] args)
        {
            return ReflectorHelper.InvokeMember(
                type, null, null,
                ReflectorHelper.CommonFlags | BindingFlags.CreateInstance | BindingFlags.Instance, args);
        }

        /// <summary>
        /// 
        /// </summary>
        public static void SetField(object target, string fieldName, object value)
        {
            ReflectorHelper.InvokeMember(
                target.GetType(), target, fieldName,
                ReflectorHelper.CommonFlags | BindingFlags.SetField | BindingFlags.Instance, value);
        }

        /// <summary>
        /// 
        /// </summary>
        public static object GetField(object target, string fieldName)
        {
            return ReflectorHelper.InvokeMember(
                target.GetType(), target, fieldName,
                ReflectorHelper.CommonFlags | BindingFlags.GetField | BindingFlags.Instance);
        }

        /// <summary>
        /// 
        /// </summary>
        public static void SetProperty(object target, string propertyName, object value)
        {
            ReflectorHelper.InvokeMember(
                target.GetType(), target, propertyName,
                ReflectorHelper.CommonFlags | BindingFlags.SetProperty | BindingFlags.Instance, value);
        }

        /// <summary>
        /// 
        /// </summary>
        public static object GetProperty(object target, string propertyName)
        {
            return ReflectorHelper.InvokeMember(
                target.GetType(), target, propertyName,
                ReflectorHelper.CommonFlags | BindingFlags.GetProperty | BindingFlags.Instance);
        }

        /// <summary>
        /// 
        /// </summary>
        public static void StaticSetField(Type type, string fieldName, object value)
        {
            ReflectorHelper.InvokeMember(
                type, null, fieldName,
                ReflectorHelper.CommonFlags | BindingFlags.SetField | BindingFlags.Static, value);
        }

        /// <summary>
        /// 
        /// </summary>
        public static object StaticGetField(Type type, string fieldName)
        {
            return ReflectorHelper.InvokeMember(
                type, null, fieldName,
                ReflectorHelper.CommonFlags | BindingFlags.GetField | BindingFlags.Static);
        }

        /// <summary>
        /// 
        /// </summary>
        public static void StaticSetProperty(Type type, string propertyName, object value)
        {
            ReflectorHelper.InvokeMember(
                type, null, propertyName,
                ReflectorHelper.CommonFlags | BindingFlags.SetProperty | BindingFlags.Static, value);
        }

        /// <summary>
        /// 
        /// </summary>
        public static object StaticGetProperty(Type type, string propertyName)
        {
            return ReflectorHelper.InvokeMember(
                type, null, propertyName,
                ReflectorHelper.CommonFlags | BindingFlags.GetProperty | BindingFlags.Static);
        }

        /// <summary>
        /// 
        /// </summary>
        public static object CallMethod(object target, string methodName, params object[] args)
        {
            return ReflectorHelper.InvokeMember(
                target.GetType(), target, methodName,
                ReflectorHelper.CommonFlags | BindingFlags.InvokeMethod | BindingFlags.Instance, args);
        }

        public static object StaticCallMethod(Type classType, string methodName)
        {
            return StaticCallMethod(classType, methodName, null);
        }

        public static object StaticCallMethod(Type classType, string methodName, object onlyArgument)
        {
            object[] arguments = new object[] { onlyArgument };
            return StaticCallMethod(classType, methodName, arguments);
        }

        public static object StaticCallMethod(Type classType, string methodName, object[] arguments)
        {
            //return ReflectorHelper.InvokeMember(
            //    type, null, null,
            //    ReflectorHelper.CommonFlags | BindingFlags.InvokeMethod | BindingFlags.Static, args);
            return classType.InvokeMember
                (methodName,
                BindingFlags.InvokeMethod,
                null, null, arguments, System.Globalization.CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// 
        /// </summary>
        private static object InvokeMember(
            Type type, object target, string memberName, BindingFlags flags, params object[] args)
        {
            return type.InvokeMember(memberName, flags, null, target, args);
        }

    }
}