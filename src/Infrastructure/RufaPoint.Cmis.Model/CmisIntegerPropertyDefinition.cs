

using RufaPoint.Cmis.Infrastructure.Interfaces;
using System.Collections.Generic;


namespace RufaPoint.Cmis.Model
{
    /// <summary>
    /// CMIS integer property definition.
    /// </summary>
    public class CmisIntegerPropertyDefinition : CmisPropertyDefinition, ICmisIntegerPropertyDefinition
    {
		/// <summary>
		/// Gets or sets the default value.
		/// </summary>
		/// <value>The default value.</value>
		public IList<int?> DefaultValue { get; set; }

		/// <summary>
		/// Indicates an explicit ordered set of single values allowed for this property.
		/// </summary>
		/// <value>The choices.</value>
		public IList<ICmisChoice<int?>> Choices { get; set; }

		/// <summary>
		/// The minimum value allowed for this property.
		/// If an application tries to set the value of this property to a value lower than minValue, the repository MUST throw a constraint exception.
		/// </summary>
		/// <value>The minimum allowed value.</value>
		public int? MinValue { get; set; }

		/// <summary>
		/// The maximum value allowed for this property.
		/// If an application tries to set the value of this property to a value higher than maxValue, the repository MUST throw a constraint exception.
		/// </summary>
		/// <value>The maximum allowed value value.</value>
        public int? MaxValue { get; set; }
    }
}
