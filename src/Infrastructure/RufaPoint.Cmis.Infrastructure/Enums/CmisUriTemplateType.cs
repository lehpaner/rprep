

namespace RufaPoint.Cmis.Infrastructure.Enums
{
    /// <summary>
    /// CMIS URI template type.
    /// </summary>
    public enum CmisUriTemplateType
    {
        /// <summary>
        /// CMIS URI template for object by id query.
        /// </summary>
        [CmisName(Constants.CmisUriTemplateTypeObjectById)]
        ObjectById,
		/// <summary>
		/// CMIS URI template for object by path query.
		/// </summary>
        [CmisName(Constants.CmisUriTemplateTypeObjectByPath)]
		ObjectByPath,
		/// <summary>
		/// CMIS URI template for queries.
		/// </summary>
        [CmisName(Constants.CmisUriTemplateTypeQuery)]
		Query,
		/// <summary>
		/// CMIS URI template for type by id query.
		/// </summary>
        [CmisName(Constants.CmisUriTemplateTypeTypeById)]
		TypeById
    }
}
