using System;

namespace Dommel
{
    public class CustomTableNameResolver: ITableNameResolver
    {
        public string ResolveTableName(Type type)
        {
            return type.Name;
        }
    }
}