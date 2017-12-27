

namespace RufaPoint.Cmis.Infrastructure.Enums
{
	/// <summary>
	/// CMIS ordering capabilities of the repository.
	/// </summary>
	public enum CmisCapabilityOrderBy
    {
		/// <summary>
		/// Ordering is not supported.
		/// </summary>
        [CmisName(Constants.CmisCapabilityOrderByNone)]
		None,

		/// <summary>
		/// Only common CMIS properties are supported.
		/// </summary>
        [CmisName(Constants.CmisCapabilityOrderByCommon)]
		Common,

		/// <summary>
		/// Common CMIS properties and custom object-type properties are supported.
		/// </summary>
        [CmisName(Constants.CmisCapabilityOrderByCustom)]
		Custom
    }
}
