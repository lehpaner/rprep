

namespace RufaPoint.Cmis.Infrastructure.Enums
{
	/// <summary>
	/// CMIS renditions capability. Indicates whether or not the repository exposes renditions of document or folder objects.
	/// </summary>
	public enum CmisCapabilityRenditions
    {
		/// <summary>
		/// The repository does not expose renditions at all.
		/// </summary>
        [CmisName(Constants.CmisCapabilityRenditionsNone)]
		None,

		/// <summary>
		/// Renditions are provided by the repository and readable by the client.
		/// </summary>
        [CmisName(Constants.CmisCapabilityRenditionsRead)]
		Read
    }
}
