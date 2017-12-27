
using RufaPoint.Cmis.Infrastructure.Enums;
using RufaPoint.Cmis.Infrastructure.Interfaces;
using System.Collections.Generic;

namespace RufaPoint.Cmis.Model
{
    /// <summary>
    /// CMIS string property definition.
    /// </summary>
    public class CmisStringPropertyDefinition : CmisPropertyDefinition, ICmisStringPropertyDefinition
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

		/// <summary>
		/// The maximum length (in characters) allowed for a value of this property.
		/// If an application attempts to set the value of this property to a string longer than the speciﬁed maximum length, the repository MUST throw a constraint exception.
		/// </summary>
		/// <value>The maximum length.</value>
        public int? MaxLength { get; set; }

        public CmisCardinality? Cardinality { get; }
        public CmisPropertyType PropertyType { get; }
        public CmisUpdatability? Updatability { get; }


    }
}
