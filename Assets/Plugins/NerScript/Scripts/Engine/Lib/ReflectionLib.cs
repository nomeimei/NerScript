using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace NerScript
{
    public static class ReflectionLib
    {
        public static BindingFlags flag = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static;

        public static MemberInfo[] GetMembers(this Type type) => type.GetMembers(flag);
        public static MemberInfo[] GetMembers(this Type type, Type memberType)
            => type.GetMembers(flag).Where(m => m.DeclaringType == memberType).ToArray();
        public static MemberInfo[] GetMember(this Type type, string name) => type.GetMember(name, flag);
        public static MemberInfo[] GetMember(this Type type, string name, Type memberType)
            => type.GetMember(name, flag).Where(m => m.DeclaringType == memberType).ToArray();


        public static FieldInfo[] GetFields(this Type type) => type.GetFields(flag);
        public static FieldInfo[] GetFields(this Type type, Type fieldType)
            => type.GetFields(flag).Where(f => f.DeclaringType == fieldType).ToArray();
        public static FieldInfo GetField(this Type type, string name) => type.GetField(name, flag);
        public static FieldInfo GetField(this Type type, string name, Type fieldType)
            => type.GetField(name, flag).ShiftArray().Where(f => f.DeclaringType == fieldType).FirstOrDefault();


        public static PropertyInfo[] GetProperties(this Type type) => type.GetProperties(flag);
        public static PropertyInfo[] GetProperties(this Type type, Type propertyType)
            => type.GetProperties(flag).Where(p => p.DeclaringType == propertyType).ToArray();
        public static PropertyInfo GetProperties(this Type type, string name) => type.GetProperty(name, flag);
        public static PropertyInfo GetProperties(this Type type, string name, Type propertyType)
            => type.GetProperty(name, flag).ShiftArray().Where(p => p.DeclaringType == propertyType).FirstOrDefault();


        public static MethodInfo[] GetMethods(this Type type) => type.GetMethods(flag);
        public static MethodInfo[] GetMethods(this Type type, Type methodType)
            => type.GetMethods(flag).Where(m => m.DeclaringType == methodType).ToArray();
        public static MethodInfo GetMethod(this Type type, string name) => type.GetMethod(name, flag);
        public static MethodInfo GetMethod(this Type type, string name, Type methodType)
            => type.GetMethod(name, flag).ShiftArray().Where(m => m.DeclaringType == methodType).FirstOrDefault();
        
        public static object GetValue(this MemberInfo info, object obj)
        {
            if (info.MemberType == MemberTypes.Field)
            {
                return ((FieldInfo)info).GetValue(obj);
            }
            else if (info.MemberType == MemberTypes.Property)
            {
                return ((PropertyInfo)info).GetValue(obj);
            }
            else if (info.MemberType == MemberTypes.Method)
            {
                return ((MethodInfo)info).Invoke(obj, new object[0]);
            }
            return default;
        }










    }
}
