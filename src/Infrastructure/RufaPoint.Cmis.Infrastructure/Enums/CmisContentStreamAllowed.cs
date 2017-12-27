

namespace RufaPoint.Cmis.Infrastructure.Enums
{
	/// <summary>
	/// Indicates whether a content stream MAY, MUST, or MUST NOT be included in objects of this type.
	/// </summary>
	public enum CmisContentStreamAllowed
    {
		/// <summary>
		/// A content stream MUST NOT be included.
		/// </summary>
        [CmisName(Constants.CmisContentStreamNotAllowed)]
		NotAllowed,
		/// <summary>
		/// A content stream MAY be included.
		/// </summary>
        [CmisName(Constants.CmisContentStreamAllowed)]
		Allowed,
		/// <summary>
		/// A content stream MUST be included (i.e. MUST be included when the object is created, and MUST NOT be deleted).
		/// </summary>
        [CmisName(Constants.CmisContentStreamRequired)]
		Required
    }
}
