
namespace RufaPoint.Cmis.Model.Atom
{
    using Cmis.Infrastructure.Interfaces;
    using RufaPoint.Cmis.Infrastructure.Enums;

    /// <summary>
    /// The atom:link element defines a relationship between a web resource (such as a page) and an RSS channel or item (OPTIONAL). The most common use is to identify an HTML representation of an entry in an RSS or Atom feed.
    /// </summary>
    public class AtomLink : IAtomLink
    {
        #region Properties

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>The title.</value>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the URI of the related resource (href).
        /// </summary>
        /// <value>The href.</value>
        public string Reference { get; set; }

        /// <summary>
        /// Gets or sets the relation (rel).
        /// </summary>
        /// <value>The relation.</value>
        public string Relation { get; set; }

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the CMIS medai type (type).
        /// </summary>
        /// <value>The CMIS media type.</value>
        public CmisMediaType MediaType { get; set; }

        #endregion
    }
}
