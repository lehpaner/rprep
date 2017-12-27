

namespace RufaPoint.Cmis.Infrastructure.Interfaces
{
    using RufaPoint.Cmis.Infrastructure.Enums;
    using System.Collections.Generic;

	/// <summary>
	/// Atom collection. See https://tools.ietf.org/html/rfc5023
	/// </summary>
	public interface IAtomCollection
    {
		/// <summary>
		/// Gets or sets the title.
		/// </summary>
		/// <value>The title.</value>
		string Title { get; set; }

		/// <summary>
		/// Gets or sets the type of the collection.
		/// </summary>
		/// <value>The type of the collection.</value>
		CmisCollectionType CollectionType { get; set; }

		/// <summary>
		/// Gets or sets the accepted media types.
		/// </summary>
		/// <value>The list of accepted media types.</value>
		IList<CmisMediaType> Accept { get; set; }

		/// <summary>
		/// Gets or sets the URI.
		/// </summary>
		/// <value>The URI.</value>
		string Uri { get; set; }
    }
}