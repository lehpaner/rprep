using RufaPoint.Cmis.Infrastructure.Interfaces;
using System.Collections.Generic;
namespace RufaPoint.Cmis.Model
{

    /// <summary>
    /// CMIS permission definition.
    /// </summary>
    public class CmisPermissionDefinition : ICmisPermissionDefinition
    {
		/// <summary>
		/// Gets the CMIS permission name.
		/// </summary>
		/// <value>The CMIS permission name.</value>
		public string Permission { get; set; }

		/// <summary>
		/// Gets the CMIS permission description.
		/// </summary>
		/// <value>The CMIS permission description.</value>
		public string Description { get; set; }

		/// <summary>
		/// Gets or sets the list of CMIS extensions.
		/// </summary>
		/// <value>The list of CMIS extensions.</value>
		public IList<ICmisExtensionElement> Extensions { get; set; }
    }
}
