

namespace RufaPoint.Cmis.Infrastructure.Enums
{
	/// <summary>
	/// CMIS join capability. Indicates the types of JOIN keywords that the Repository can fulﬁll in queries.
	/// </summary>
	public enum CmisCapabilityJoin
    {
		/// <summary>
		/// The repository cannot fulﬁll any queries that include any JOIN clauses on two primary types. If the Repository supports secondary types, JOINs on secondary types SHOULD be supported, even if the support level is none.
		/// </summary>
        [CmisName(Constants.CmisCapabilityJoinNone)]
		None,

		/// <summary>
		/// The repository can fulﬁll queries that include an INNER JOIN clause, but cannot fulﬁll queries that include other types of JOIN clauses.
		/// </summary>
        [CmisName(Constants.CmisCapabilityJoinInnerOnly)]
		InnerOnly,

		/// <summary>
		/// The repository can fulﬁll queries that include any type of JOIN clause deﬁned by the CMIS query grammar.
		/// </summary>
        [CmisName(Constants.CmisCapabilityJoinInnerAndOuter)]
		InnerAndOuter
    }
}
