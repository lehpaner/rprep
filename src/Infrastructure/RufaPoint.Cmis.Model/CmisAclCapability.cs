
namespace RufaPoint.Cmis.Model
{
    using System.Collections.Generic;
    using Cmis.Infrastructure;
    using RufaPoint.Cmis.Infrastructure.Interfaces;
    using RufaPoint.Cmis.Infrastructure.Enums;

    /// <summary>
    /// CMIS ACL capability.
    /// </summary>
    public class CmisAclCapability : ICmisAclCapability
    {
		/// <summary>
		/// Gets the supported types of permissions.
		/// </summary>
		/// <value>The supported permissions.</value>
		public CmisSupportedPermissions SupportedPermissions { get; set; }

		/// <summary>
		/// Gets the allowed value(s) for applyACL, which control how non-direct ACEs are handled by the repository.
		/// </summary>
		/// <value>The ACL propagation value.</value>
		public CmisAclProgagation Propagation { get; set; }

		/// <summary>
		/// Gets the list of repository-speciﬁc permissions the repository supports for managing ACEs.
		/// </summary>
		/// <value>The permissions.</value>
		public IList<ICmisPermissionDefinition> Permissions { get; set; }

		/// <summary>
		/// Gets the list of mappings for the CMIS basic permissions to allowable actions.
		/// </summary>
		/// <value>The list of permission mappings.</value>
		public IList<ICmisPermissionMapping> PermissionMapping { get; set; }

		/// <summary>
		/// Gets or sets the list of CMIS extensions.
		/// </summary>
		/// <value>The list of CMIS extensions.</value>
		public IList<ICmisExtensionElement> Extensions { get; set; }
    }
}
