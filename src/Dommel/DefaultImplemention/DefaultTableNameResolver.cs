using System;
using System.Reflection;

namespace Dommel
{
    public class DefaultTableNameResolver : ITableNameResolver
    {
        /// <summary>
        /// Resolves the table name by making the type plural (+ 's', Product -> Products)
        /// and removing the 'I' prefix for interfaces.
        /// </summary>
        public virtual string ResolveTableName(Type type)
        {
            var name = type.Name + "s";
            if (type.GetTypeInfo().IsInterface && name.StartsWith("I"))
            {
                name = name.Substring(1);
            }

            // todo: add [Table] attribute support.
            return name;
        }
    }
}
