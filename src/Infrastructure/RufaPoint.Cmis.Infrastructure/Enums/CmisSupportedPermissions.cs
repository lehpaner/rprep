

namespace RufaPoint.Cmis.Infrastructure.Enums
{
    /// <summary>
    /// CMIS supported types of permissions.
    /// </summary>
    public enum CmisSupportedPermissions
    {
        /// <summary>
        /// CMIS basic permissions.
        /// </summary>
        [CmisName(Constants.CmisPermissionTypeBasic)]
		Basic,

        /// <summary>
        /// CMIS repository specific permissions.
        /// </summary>
        [CmisName(Constants.CmisPermissionTypeRepository)]
        Repository,

        /// <summary>
        /// CMIS basic and repository specific permissions.
        /// </summary>
        [CmisName(Constants.CmisPermissionTypeBoth)]
        Both
	}
}
