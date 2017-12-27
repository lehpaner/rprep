

namespace RufaPoint.Cmis.Infrastructure.Enums
{
	/// <summary>
	/// CMIS content stream update capabilities. Indicates the support a repository has for updating a documents content stream.
	/// </summary>
	public enum CmisCapabilityContentStreamUpdatability
    {
		/// <summary>
		/// The content stream may never be updated.
		/// </summary>
        [CmisName(Constants.CmisCapabilityContentStreamUpdatabilityNone)]
		None,

		/// <summary>
		/// The content stream may be updated any time.
		/// </summary>
        [CmisName(Constants.CmisCapabilityContentStreamUpdatabilityAnyTime)]
		Anytime,

		/// <summary>
		/// The content stream may be updated only when checked out.
		/// </summary>
        [CmisName(Constants.CmisCapabilityContentStreamUpdatabilityPwcOnly)]
		PWCOnly
    }
}
