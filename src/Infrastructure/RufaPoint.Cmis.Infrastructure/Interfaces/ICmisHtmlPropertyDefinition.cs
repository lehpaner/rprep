using System.Collections.Generic;

namespace RufaPoint.Cmis.Infrastructure.Interfaces
{
    /// <summary>
    /// CMIS HTML property definition.
    /// </summary>
    public interface ICmisHtmlPropertyDefinition : ICmisPropertyDefinition
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
    }
}
