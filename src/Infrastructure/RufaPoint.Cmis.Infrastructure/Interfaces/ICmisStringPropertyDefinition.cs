
using System.Collections.Generic;

namespace RufaPoint.Cmis.Infrastructure.Interfaces
{
    /// <summary>
    /// CMIS string property definition.
    /// </summary>
    public interface ICmisStringPropertyDefinition : ICmisPropertyDefinition
    {
		/// <summary>
		/// Gets the default value.
		/// </summary>
		/// <value>The default value.</value>
		IList<string> DefaultValue { get; }

		/// <summary>
		/// Indicates an explicit ordered set of single values allowed for this property.
		/// </summary>
		/// <value>The choices.</value>
		IList<ICmisChoice<string>> Choices { get; }

		/// <summary>
		/// The maximum length (in characters) allowed for a value of this property.
		/// If an application attempts to set the value of this property to a string longer than the speciﬁed maximum length, the repository MUST throw a constraint exception.
        /// </summary>
        /// <value>The maximum length.</value>
        int? MaxLength { get; }
    }
}
