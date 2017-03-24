using System.Reflection;

namespace Dommel
{
    public interface ISqlBuilder
    {
        /// <summary>
        /// Builds an insert query using the specified table name, column names and parameter names.
        /// A query to fetch the new id will be included as well.
        /// </summary>
        /// <param name="tableName">The name of the table to query.</param>
        /// <param name="columnNames">The names of the columns in the table.</param>
        /// <param name="paramNames">The names of the parameters in the database command.</param>
        /// <param name="keyProperty">
        /// The key property. This can be used to query a specific column for the new id. This is
        /// optional.
        /// </param>
        /// <returns>An insert query including a query to fetch the new id.</returns>
        string BuildInsert(string tableName, string[] columnNames, string[] paramNames, PropertyInfo keyProperty);
    }
}
