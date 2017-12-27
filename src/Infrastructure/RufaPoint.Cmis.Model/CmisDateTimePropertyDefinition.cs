
using RufaPoint.Cmis.Infrastructure.Enums;
using RufaPoint.Cmis.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;


namespace RufaPoint.Cmis.Model
{
    /// <summary>
    /// CMIS date time property definition.
    /// </summary>
    public class CmisDateTimePropertyDefinition : ICmisPropertyDefinition, ICmisDateTimePropertyDefinition
    {
		/// <summary>
		/// Gets or sets the default value.
		/// </summary>
		/// <value>The default value.</value>
        public IList<DateTime?> DefaultValue { get; set; }

		/// <summary>
		/// Indicates an explicit ordered set of single values allowed for this property.
		/// </summary>
		/// <value>The choices.</value>
        public IList<ICmisChoice<DateTime?>> Choices { get; set; }

		/// <summary>
		/// This is the CMIS date time resolution supported for values of this property.
		/// </summary>
		/// <value>The CMIS date time resolution.</value>
        public CmisDateTimeResolution? Resolution { get; set; }

        public string Id => throw new NotImplementedException();

        public string LocalName => throw new NotImplementedException();

        public string LocalNamespace => throw new NotImplementedException();

        public string QueryName => throw new NotImplementedException();

        public string DisplayName => throw new NotImplementedException();

        public string Description => throw new NotImplementedException();

        public CmisPropertyType PropertyType => throw new NotImplementedException();

        public CmisCardinality? Cardinality => throw new NotImplementedException();

        public CmisUpdatability? Updatability => throw new NotImplementedException();

        public bool? Inherited => throw new NotImplementedException();

        public bool? Required => throw new NotImplementedException();

        public bool? Queryable => throw new NotImplementedException();

        public bool? Orderable => throw new NotImplementedException();

        public bool? OpenChoice => throw new NotImplementedException();

        public IList<ICmisExtensionElement> Extensions { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
