
namespace RufaPoint.Cmis.Infrastructure.Enums
{
    /// <summary>
    /// CMIS basic permission.
    /// </summary>
    public enum CmisBasicPermission
    {
		/// <summary>
		/// Expresses the "permission to read" properties AND content of an object.
		/// </summary>
		[CmisName(Constants.CmisBasicPermissionRead)]
        Read,
		/// <summary>
		/// Expresses the "permission to write" properties AND content of an object. It MAY include the cmis:read permission.
		/// </summary>
		[CmisName(Constants.CmisBasicPermissionWrite)]
        Write,
		/// <summary>
		/// SHOULD express all the permissions of a repository. It SHOULD include all other basic CMIS permissions.
		/// </summary>
		[CmisName(Constants.CmisBasicPermissionAll)]
        All
    }
}
