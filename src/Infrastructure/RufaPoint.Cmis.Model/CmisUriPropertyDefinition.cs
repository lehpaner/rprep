
using RufaPoint.Cmis.Infrastructure.Interfaces;
using System.Collections.Generic;

namespace RufaPoint.Cmis.Model
{
    /// <summary>
    /// CMIS URI property definition.
    /// </summary>
    public class CmisUriPropertyDefinition : CmisPropertyDefinition, ICmisUriPropertyDefinition
    {
		/// <summary>
		/// Gets or sets the default value.
		/// </summary>
		/// <value>The default value.</value>
        public IList<string> DefaultValue { get; set; }

		/// <summary>
		/// Indicates an explicit ordered set of single values allowed for this property.
		/// </summary>
		/// <value>The choices.</value>
        public IList<ICmisChoice<string>> Choices { get; set; }
    }
}
