


using RufaPoint.Cmis.Infrastructure.Enums;

namespace RufaPoint.Cmis.Infrastructure.Interfaces
{
	/// <summary>
	/// The atom:link element defines a relationship between a web resource (such as a page) and an RSS channel or item (OPTIONAL). The most common use is to identify an HTML representation of an entry in an RSS or Atom feed.
	/// </summary>
	public interface IAtomLink
    {
		/// <summary>
		/// Gets or sets the title.
		/// </summary>
		/// <value>The title.</value>
		string Title { get; set; }

		/// <summary>
		/// Gets or sets the URI of the related resource (href).
		/// </summary>
		/// <value>The href.</value>
		string Reference { get; set; }

		/// <summary>
		/// Gets or sets the relation (rel).
		/// </summary>
		/// <value>The relation.</value>
		string Relation { get; set; }

		/// <summary>
		/// Gets or sets the identifier.
		/// </summary>
		/// <value>The identifier.</value>
		string Id { get; set; }

		/// <summary>
		/// Gets or sets the CMIS medai type (type).
		/// </summary>
		/// <value>The CMIS media type.</value>
		CmisMediaType MediaType { get; set; }
    }
}