﻿using System;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Stealer
{
    public class Spy
    {
        public string StealFieldInfo(string investigatedClass, params string[] requestedFields)
        {
            Type classType = Type.GetType(investigatedClass);
            FieldInfo[] classFields = classType.GetFields(
                BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public);
            StringBuilder stringBuilder = new StringBuilder();

            Object classInstance = Activator.CreateInstance(classType, new object[] {   });
            stringBuilder.AppendLine($"Class under investigation: {investigatedClass}");

            foreach (FieldInfo field in classFields.Where(f => requestedFields.Contains(f.Name)))
            {
                stringBuilder.AppendLine($"{field.Name} = {field.GetValue(classInstance)}");
            }
            return stringBuilder.ToString().Trim();
        }

        public string AnalyzeAccessModifiers(string investigatedClass)
        {
            Type classType = Type.GetType(investigatedClass);
            FieldInfo[] classFields = classType.GetFields(
                BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public);
            MethodInfo[] classPublicMethods = classType.GetMethods(BindingFlags.Instance | BindingFlags.Public);
            MethodInfo[] classNonPublicMethods = classType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);

            StringBuilder stringBuilder = new StringBuilder();
            foreach (FieldInfo field in classFields)
            {
                stringBuilder.AppendLine($"{field.Name} must be private!");
            }
            foreach (MethodInfo method in classPublicMethods.Where(m => m.Name.StartsWith("get")))
            {
                stringBuilder.AppendLine($"{method.Name} have to be public!");
            }
            foreach (MethodInfo method in classNonPublicMethods.Where(m => m.Name.StartsWith("set")))
            {
                stringBuilder.AppendLine($"{method.Name} have to be private!");
            }
            return stringBuilder.ToString().Trim();
        }
        public string RevealPrivateMethods(string investigatedClass)
        {
            Type classType = Type.GetType(investigatedClass);
            MethodInfo[] classMethods = classType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);

            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine($"All Private Methods of Class: {investigatedClass}");
            stringBuilder.AppendLine($"Base Class: {classType.BaseType.Name}");

            foreach (MethodInfo method in classMethods)
            {
                stringBuilder.AppendLine(method.Name);
            }
            return stringBuilder.ToString().Trim();
        }
        public string CollectGettersAndSetters(string className)
        {
            Type classType = Type.GetType(className);

            MethodInfo[] methods = classType.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);

            StringBuilder sb = new StringBuilder();

            foreach (var method in methods.Where(m => m.Name.StartsWith("get")))
            {
                sb.AppendLine($"{method.Name} will return {method.ReturnType}");
            }

            foreach (var method in methods.Where(m => m.Name.StartsWith("set")))
            {
                sb.AppendLine($"{method.Name} will set field of {method.GetParameters().First().ParameterType}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
