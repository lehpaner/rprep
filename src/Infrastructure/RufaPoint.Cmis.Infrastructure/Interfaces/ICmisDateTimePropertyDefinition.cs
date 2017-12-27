

using RufaPoint.Cmis.Infrastructure.Enums;
using System;
using System.Collections.Generic;

namespace RufaPoint.Cmis.Infrastructure.Interfaces
{
    /// <summary>
    /// CMIS date time property definition.
    /// </summary>
    public interface ICmisDateTimePropertyDefinition : ICmisPropertyDefinition
    {
		/// <summary>
		/// Gets the default value.
		/// </summary>
		/// <value>The default value.</value>
		IList<DateTime?> DefaultValue { get; }

		/// <summary>
		/// Indicates an explicit ordered set of single values allowed for this property.
		/// </summary>
		/// <value>The choices.</value>
		IList<ICmisChoice<DateTime?>> Choices { get; }

		/// <summary>
		/// This is the CMIS date time resolution supported for values of this property.
		/// </summary>
		/// <value>The CMIS date time resolution.</value>
		CmisDateTimeResolution? Resolution { get; }
    }
}
