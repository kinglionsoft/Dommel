using System;
using System.Collections.Generic;
using System.Reflection;

namespace Dommel
{
    public class DefaultPropertyResolver : PropertyResolverBase
    {
        /// <inheritdoc/>
        public override IEnumerable<PropertyInfo> ResolveProperties(Type type)
        {
            return FilterComplexTypes(type.GetProperties());
        }
    }
}
