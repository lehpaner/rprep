

namespace RufaPoint.Cmis.Infrastructure.Interfaces
{
    using RufaPoint.Cmis.Infrastructure.Enums;
    using System.Collections.Generic;

    /// <summary>
    /// CMIS ACL capability.
    /// </summary>
    public interface ICmisAclCapability : ICmisExtensionData
    {
		/// <summary>
		/// Gets the supported types of permissions.
		/// </summary>
		/// <value>The supported permissions.</value>
		CmisSupportedPermissions SupportedPermissions { get; }

		/// <summary>
		/// Gets the allowed value(s) for applyACL, which control how non-direct ACEs are handled by the repository.
		/// </summary>
		/// <value>The ACL propagation value.</value>
		CmisAclProgagation Propagation { get; }

		/// <summary>
		/// Gets the list of repository-speciﬁc permissions the repository supports for managing ACEs.
		/// </summary>
		/// <value>The permissions.</value>
        IList<ICmisPermissionDefinition> Permissions { get; }

		/// <summary>
		/// Gets the list of mappings for the CMIS basic permissions to allowable actions.
		/// </summary>
		/// <value>The list of permission mappings.</value>
		IList<ICmisPermissionMapping> PermissionMapping { get; }
    }
}
