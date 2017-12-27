


using RufaPoint.Cmis.Infrastructure.Enums;
using RufaPoint.Cmis.Infrastructure.Interfaces;

namespace RufaPoint.Cmis.Model
{
    /// <summary>
    /// CMIS document type definition. Document objects are the elementary information entities managed by the repository.
    /// </summary>
    public class CmisDocumentTypeDefinition : CmisTypeDefinitionBase, ICmisDocumentTypeDefinition
    {
		/// <summary>
		/// Can be acted upon via the Versioning Services (for example: checkOut, checkIn).
		/// </summary>
		/// <value><c>true</c> if versionable; otherwise, <c>false</c>.</value>
        public bool? Versionable { get; set; }

		/// <summary>
		/// Gets the content stream allowed.
		/// </summary>
		/// <value>The content stream allowed.</value>
        public CmisContentStreamAllowed? ContentStreamAllowed { get; set; }
    }
}