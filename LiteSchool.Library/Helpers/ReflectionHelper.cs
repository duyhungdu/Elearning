using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Runtime.Serialization;

namespace LiteSchool.Library.Helpers
{
    public static class ReflectionHelper
    {
        public static IEnumerable<Type> InterfaceScan<T>(string assemblyName)
        {
            Type type = typeof(T);
            return Assembly.Load(assemblyName).GetTypes().Where(t => t.IsInterface && t.GetInterfaces().Contains(type));
        }

        public static object CreateInstanceFromEntryAssembly(string typeFullName)
        {
            Assembly assembly = Assembly.GetEntryAssembly();
            Type type = GetType(assembly.GetName().Name, typeFullName);
            return Activator.CreateInstance(type, null);
        }

        public static Type GetType(string assemblyName, string typeName)
        {
            Assembly assembly = null;
            Assembly[] Assemblies = AppDomain.CurrentDomain.GetAssemblies();
            foreach (Assembly item in Assemblies)
            {
                if (item.GetName().Name == assemblyName)
                    assembly = item;
            }

            if (assembly == null) return null;            
            return assembly.GetType(typeName);
        }
    }
}
