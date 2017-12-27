
namespace RufaPoint.Cmis.Model.Atom
{
    using System.Collections.Generic;
    using Cmis.Infrastructure.Interfaces;
    using RufaPoint.Cmis.Infrastructure.Enums;

    /// <summary>
    /// Atom collection. See https://tools.ietf.org/html/rfc5023
    /// </summary>
    public class AtomCollection : IAtomCollection
    {
        #region Properties

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>The title.</value>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the type of the collection.
        /// </summary>
        /// <value>The type of the collection.</value>
        public CmisCollectionType CollectionType { get; set; }

        /// <summary>
        /// Gets or sets the accepted media types.
        /// </summary>
        /// <value>The list of accepted media types.</value>
        public IList<CmisMediaType> Accept { get; set; }

        /// <summary>
        /// Gets or sets the URI.
        /// </summary>
        /// <value>The URI.</value>
        public string Uri { get; set; }

        #endregion
    }
}
