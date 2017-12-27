

namespace RufaPoint.Cmis.Infrastructure.Enums
{
	/// <summary>
	/// CMIS property cardinality. Indicates whether a property can have "zero or one" or "zero or more" values.
	/// </summary>
	public enum CmisCardinality
    {
		/// <summary>
		/// Property can have zero or one values (if property is not required), or exactly one value (if property is required).
		/// </summary>
        [CmisName(Constants.CmisCardinalitySingle)]
		Single,

		/// <summary>
		/// Property can have zero or more values (if property is not required), or one or more values (if property is required).
		/// </summary>
		/// <remarks>Repositories SHOULD preserve the ordering of values in a multi-valued property. That is, the order in which the values of a multi-valued property are returned in "get" services operations SHOULD be the same as the order in which they were supplied during previous create/update operation.</remarks>
        [CmisName(Constants.CmisCardinalityMulti)]
        Multi
    }
}
