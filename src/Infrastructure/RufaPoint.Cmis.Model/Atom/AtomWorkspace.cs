
namespace RufaPoint.Cmis.Model.Atom
{
    using System.Collections.Generic;
    using RufaPoint.Cmis.Infrastructure.Interfaces;

    /// <summary>
    /// Atom workspace. Represents an Atom workspace. See https://tools.ietf.org/html/rfc5023
    /// </summary>
    public class AtomWorkspace : IAtomWorkspace
    {
        #region Properties

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>The title.</value>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the list of collections attached to this workspace.
        /// </summary>
        /// <value>The list of collections.</value>
        public IList<IAtomCollection> Collections { get; set; }

        /// <summary>
        /// Gets or sets the repository info.
        /// </summary>
        /// <value>The repository info.</value>
        public ICmisRepositoryInfo RepositoryInfo { get; set; }

        /// <summary>
        /// Gets or sets the links.
        /// </summary>
        /// <value>The links.</value>
        public IList<IAtomLink> Links { get; set; }

        /// <summary>
        /// Gets or sets the URI templates.
        /// </summary>
        /// <value>The URI templates.</value>
        public IList<IAtomUriTemplate> UriTemplates { get; set; }

        #endregion
    }
}
