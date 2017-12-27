
namespace RufaPoint.Cmis.Model.Atom
{
    using System.Collections.Generic;
    using Cmis.Infrastructure.Interfaces;

    /// <summary>
    /// Atom service. Represents an Atom service document. See https://tools.ietf.org/html/rfc5023
    /// </summary>
    public class AtomService : IAtomService
    {
        #region Properties

        /// <summary>
        /// Gets or sets the attached list of workspaces.
        /// </summary>
        /// <value>The list of workspaces.</value>
        public IList<IAtomWorkspace> Workspaces { get; set; }

        #endregion
    }
}
