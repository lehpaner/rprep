

using RufaPoint.Cmis.Infrastructure.Enums;

namespace RufaPoint.Cmis.Infrastructure.Interfaces
{
	/// <summary>
	/// CMIS document type definition. Document objects are the elementary information entities managed by the repository.
	/// </summary>
	public interface ICmisDocumentTypeDefinition : ICmisTypeDefinition
    {
		/// <summary>
		/// Can be acted upon via the Versioning Services (for example: checkOut, checkIn).
		/// </summary>
		/// <value><c>true</c> if versionable; otherwise, <c>false</c>.</value>
		bool? Versionable { get; }

		/// <summary>
		/// Gets the content stream allowed.
		/// </summary>
		/// <value>The content stream allowed.</value>
		CmisContentStreamAllowed? ContentStreamAllowed { get; }
    }
}
