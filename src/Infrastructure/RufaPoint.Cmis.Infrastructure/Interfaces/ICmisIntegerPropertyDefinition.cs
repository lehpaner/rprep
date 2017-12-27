

using System.Collections.Generic;

namespace RufaPoint.Cmis.Infrastructure.Interfaces
{
    /// <summary>
    /// CMIS integer property definition.
    /// </summary>
    public interface ICmisIntegerPropertyDefinition : ICmisPropertyDefinition
    {
        /// <summary>
        /// Gets the default value.
        /// </summary>
        /// <value>The default value.</value>
        IList<int?> DefaultValue { get; }

		/// <summary>
		/// Indicates an explicit ordered set of single values allowed for this property.
		/// </summary>
		/// <value>The choices.</value>
		IList<ICmisChoice<int?>> Choices { get; }

		/// <summary>
		/// The minimum value allowed for this property.
		/// If an application tries to set the value of this property to a value lower than minValue, the repository MUST throw a constraint exception.
        /// </summary>
        /// <value>The minimum allowed value.</value>
        int? MinValue { get; }

		/// <summary>
		/// The maximum value allowed for this property.
		/// If an application tries to set the value of this property to a value higher than maxValue, the repository MUST throw a constraint exception.
		/// </summary>
		/// <value>The maximum allowed value value.</value>
		int? MaxValue { get; }
    }
}
