

namespace RufaPoint.Cmis.Infrastructure.Interfaces
{
    using System.Collections.Generic;

	/// <summary>
	/// Atom service. Represents an Atom service document. See https://tools.ietf.org/html/rfc5023
	/// </summary>
	public interface IAtomService
    {
		/// <summary>
		/// Gets or sets the attached list of workspaces.
		/// </summary>
		/// <value>The list of workspaces.</value>
		IList<IAtomWorkspace> Workspaces { get; set; }
    }
}
