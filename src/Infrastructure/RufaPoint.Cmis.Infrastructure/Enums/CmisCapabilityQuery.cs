

namespace RufaPoint.Cmis.Infrastructure.Enums
{
	/// <summary>
	/// CMIS query capability. Indicates the types of queries that the Repository has the ability to fulﬁll.
	/// </summary>
	public enum CmisCapabilityQuery
    {
		/// <summary>
		/// No queries of any kind can be fulﬁlled.
		/// </summary>
        [CmisName(Constants.CmisCapabilityQueryNone)]
		None,

		/// <summary>
		/// Only queries that ﬁlter based on object properties can be fulﬁlled. Speciﬁcally, the CONTAINS() predicate function is not supported.
		/// </summary>
        [CmisName(Constants.CmisCapabilityQueryMetadataOnly)]
		MetadataOnly,

		/// <summary>
		/// Only queries that ﬁlter based on the full-text content of documents can be fulﬁlled. Speciﬁcally, only the CONTAINS() predicate function can be included in the WHERE clause.
		/// </summary>
        [CmisName(Constants.CmisCapabilityQueryFulltextOnly)]
		FulltextOnly,

		/// <summary>
		/// The repository can fulﬁll queries that ﬁlter EITHER on the full-text content of documents OR on their properties, but NOT if both types of ﬁlters are included in the same query.
		/// </summary>
        [CmisName(Constants.CmisCapabilityQueryBothSeparate)]
		BothSeparate,

		/// <summary>
		/// The repository can fulﬁll queries that ﬁlter on both the full-text content of documents and their properties in the same query.
		/// </summary>
        [CmisName(Constants.CmisCapabilityQueryBothCombined)]
		BothCombined
    }
}
