

namespace RufaPoint.Cmis.Infrastructure.Enums
{
	/// <summary>
	/// CMIS changes capability. ndicates what level of changes (if any) the repository exposes via the getContentChanges service.
	/// </summary>
	public enum CmisCapabilityChanges
    {
		/// <summary>
		/// The repository does not support the change log feature.
		/// </summary>
        [CmisName(Constants.CmisCapabilityChangesNone)]
		None,

		/// <summary>
		/// The change log can return only the object ids for changed objects in the repository and an indication of the type of change, not details of the actual change.
		/// </summary>
        [CmisName(Constants.CmisCapabilityChangesObjectIdsOnly)]
		ObjectIdsOnly,

		/// <summary>
		/// The change log can return properties and the object id for the changed objects.
		/// </summary>
        [CmisName(Constants.CmisCapabilityChangesProperties)]
		Properties,

		/// <summary>
		/// The change log can return the object ids for changed objects in the repository and more information about the actual change.
		/// </summary>
        [CmisName(Constants.CmisCapabilityChangesAll)]
		All
    }
}
