

namespace RufaPoint.Cmis.Infrastructure.Enums
{
	/// <summary>
	/// CMIS ACL capability. Indicates the level of support for ACLs by the repository.
	/// </summary>
	public enum CmisCapabilityACL
    {
		/// <summary>
		/// The repository does not support ACL services.
		/// </summary>
        [CmisName(Constants.CmisCapabilityACLNone)]
		None,

		/// <summary>
		/// The repository supports discovery of ACLs (getACL and other services).
		/// </summary>
        [CmisName(Constants.CmisCapabilityACLDiscover)]
		Discover,

		/// <summary>
		/// The repository supports discovery of ACLs AND applying ACLs (getACL and applyACL services).
		/// </summary>
        [CmisName(Constants.CmisCapabilityACLManage)]
		Manage
    }
}
