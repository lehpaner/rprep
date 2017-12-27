
using RufaPoint.Cmis.Infrastructure.Interfaces;
using System.Collections.Generic;
using RufaPoint.Cmis.Infrastructure.Enums;

namespace RufaPoint.Cmis.Model
{
    /// <summary>
    /// CMIS boolean property definition.
    /// </summary>
    public class CmisBooleanPropertyDefinition : ICmisPropertyDefinition, ICmisBooleanPropertyDefinition
    {
		/// <summary>
		/// Gets or sets the default value.
		/// </summary>
		/// <value>The default value.</value>
        public IList<bool?> DefaultValue { get; set; }

		/// <summary>
		/// Indicates an explicit ordered set of single values allowed for this property.
		/// </summary>
		/// <value>The choices.</value>
        public IList<ICmisChoice<bool?>> Choices { get; set; }

        public string Id => throw new System.NotImplementedException();

        public string LocalName => throw new System.NotImplementedException();

        public string LocalNamespace => throw new System.NotImplementedException();

        public string QueryName => throw new System.NotImplementedException();

        public string DisplayName => throw new System.NotImplementedException();

        public string Description => throw new System.NotImplementedException();

        public CmisPropertyType PropertyType => throw new System.NotImplementedException();

        public CmisCardinality? Cardinality => throw new System.NotImplementedException();

        public CmisUpdatability? Updatability => throw new System.NotImplementedException();

        public bool? Inherited => throw new System.NotImplementedException();

        public bool? Required => throw new System.NotImplementedException();

        public bool? Queryable => throw new System.NotImplementedException();

        public bool? Orderable => throw new System.NotImplementedException();

        public bool? OpenChoice => throw new System.NotImplementedException();

        public IList<ICmisExtensionElement> Extensions { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    }
}
