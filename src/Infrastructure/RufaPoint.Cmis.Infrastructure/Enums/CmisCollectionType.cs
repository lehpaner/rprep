

namespace RufaPoint.Cmis.Infrastructure.Enums
{
    /// <summary>
    /// CMIS collection type. Used in Atom service document with the cmisra namespace to identify th type of a collection.
    /// </summary>
    public enum CmisCollectionType
    {
		/// <summary>
		/// Root Folder Children Collection: Root folder of the repository.
		/// </summary>
        [CmisName(Constants.CmisCollectionTypeRoot)]
		Root,
		/// <summary>
		/// Types Children Collection: Collection containing the base types in the repository.
		/// </summary>
        [CmisName(Constants.CmisCollectionTypeTypes)]
		Types,
		/// <summary>
		/// CheckedOut collection: collection containing all checked out documents user can see.
		/// </summary>
        [CmisName(Constants.CmisCollectionTypeCheckedOut)]
		CheckedOut,
		/// <summary>
		/// Query collection: Collection for posting queries to be executed.
		/// </summary>
        [CmisName(Constants.CmisCollectionTypeQuery)]
		Query,
		/// <summary>
		/// Unﬁled collection: Collection for posting documents to be unﬁled; read can be disabled.
		/// </summary>
        [CmisName(Constants.CmisCollectionTypeUnfiled)]
		Unfiled,
		/// <summary>
		/// Bulk update collection: Collection for posting property updates for multiple objects at once.
		/// </summary>
        [CmisName(Constants.CmisCollectionTypeUpdate)]
		Update
    }
}
