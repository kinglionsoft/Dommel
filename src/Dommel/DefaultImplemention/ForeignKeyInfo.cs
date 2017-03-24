using System.Reflection;

namespace Dommel
{
    internal class ForeignKeyInfo
    {
        public ForeignKeyInfo(PropertyInfo propertyInfo, ForeignKeyRelation relation)
        {
            PropertyInfo = propertyInfo;
            Relation = relation;
        }

        public PropertyInfo PropertyInfo { get; private set; }

        public ForeignKeyRelation Relation { get; private set; }
    }
}