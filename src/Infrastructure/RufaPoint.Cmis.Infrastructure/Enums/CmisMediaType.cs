

namespace RufaPoint.Cmis.Infrastructure.Enums
{
    /// <summary>
    /// CMIS allowed media types.
    /// </summary>
    public enum CmisMediaType
    {
        /// <summary>
        /// Unknown media type. Equals to application/octet-stream.
        /// </summary>
        [CmisName(Constants.CmisMediaTypeUnknown)]
        Unknown,
		/// <summary>
		/// Atom service media type. application/atomsvc+xml
		/// </summary>
        [CmisName(Constants.CmisMediaTypeService)]
		Service,
		/// <summary>
		/// Atom Feed media type. application/atom+xml;type=feed
		/// </summary>
        [CmisName(Constants.CmisMediaTypeFeed)]
		Feed,
		/// <summary>
		/// Atom entry media type. application/atom+xml;type=entry
		/// </summary>
        [CmisName(Constants.CmisMediaTypeEntry)]
		Entry,
		/// <summary>
		/// Atom Children media type. application/atom+xml;type=feed
		/// </summary>
        [CmisName(Constants.CmisMediaTypeChildren)]
		Children,
		/// <summary>
		/// CMIS Tree media type. application/cmistree+xml
		/// </summary>
        [CmisName(Constants.CmisMediaTypeDescendants)]
		Descendants,
		/// <summary>
		/// Atom Query media type. application/cmisquery+xml
		/// </summary>
        [CmisName(Constants.CmisMediaTypeQuery)]
		Query,
		/// <summary>
		/// CMIS allowable action media type. application/cmisallowableactions+xml
		/// </summary>
        [CmisName(Constants.CmisMediaTypeAllowableAction)]
		AllowableAction,
		/// <summary>
		/// CMIS ACL media type. application/cmisacl+xml
		/// </summary>
        [CmisName(Constants.CmisMediaTypeAcl)]
		Acl,
		/// <summary>
		/// CMIS Atom media type. application/cmisatom+xml
		/// </summary>
		[CmisName(Constants.CmisMediaTypeAtom)]
		CmisAtom
    }
}
