
using RufaPoint.Cmis.Infrastructure.Interfaces;
using System.Collections.Generic;
using RufaPoint.Cmis.Infrastructure.Enums;

namespace RufaPoint.Cmis.Model
{
    /// <summary>
    /// CMIS decimal property definition.
    /// </summary>
    public class CmisDecimalPropertyDefinition : ICmisPropertyDefinition, ICmisDecimalPropertyDefinition
    {
		/// <summary>
		/// Gets or sets the default value.
		/// </summary>
		/// <value>The default value.</value>
		public IList<decimal?> DefaultValue { get; set; }

		/// <summary>
		/// Indicates an explicit ordered set of single values allowed for this property.
		/// </summary>
		/// <value>The choices.</value>
		public IList<ICmisChoice<decimal?>> Choices { get; set; }

		/// <summary>
		/// The minimum value allowed for this property.
		/// If an application tries to set the value of this property to a value lower than minValue, the repository MUST throw a constraint exception.
		/// </summary>
		/// <value>The minimum allowed value.</value>
		public decimal? MinValue { get; set; }

		/// <summary>
		/// The maximum value allowed for this property.
		/// If an application tries to set the value of this property to a value higher than maxValue, the repository MUST throw a constraint exception.
		/// </summary>
		/// <value>The maximum allowed value value.</value>
		public decimal? MaxValue { get; set; }

		/// <summary>
		/// This is the decimal precision in bits supported for values of this property.
		/// </summary>
		/// <value>The decimal precision.</value>
        public CmisDecimalPrecision? Precision { get; set; }

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
