
namespace RufaPoint.Cmis.Model
{
    using RufaPoint.Cmis.Infrastructure.Interfaces;
    using System.Collections.Generic;

	/// <summary>
	/// CMIS extension data. Holds a list of <see cref="ICmisExtensionElement"/> instances that represent optional extension data to the CMIS specification.
	/// </summary>
	public class CmisExtensionData : ICmisExtensionData
    {
		/// <summary>
		/// Gets or sets the list of CMIS extensions.
		/// </summary>
		/// <value>The list of CMIS extensions.</value>
		public IList<ICmisExtensionElement> Extensions { get; set; }
    }
}
