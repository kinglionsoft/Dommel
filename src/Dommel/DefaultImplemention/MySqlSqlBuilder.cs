using System.Reflection;

namespace Dommel
{
    internal sealed class MySqlSqlBuilder : ISqlBuilder
    {
        public string BuildInsert(string tableName, string[] columnNames, string[] paramNames, PropertyInfo keyProperty)
        {
            return $"insert into {tableName} ({string.Join(", ", columnNames)}) values ({string.Join(", ", paramNames)}); select LAST_INSERT_ID() id";
        }
    }
}
