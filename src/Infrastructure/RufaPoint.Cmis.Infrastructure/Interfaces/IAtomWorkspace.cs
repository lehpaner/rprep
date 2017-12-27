

namespace RufaPoint.Cmis.Infrastructure.Interfaces
{
    using System.Collections.Generic;

	/// <summary>
	/// Atom workspace. Represents an Atom workspace. See https://tools.ietf.org/html/rfc5023
	/// </summary>
	public interface IAtomWorkspace
    {
		/// <summary>
		/// Gets or sets the title.
		/// </summary>
		/// <value>The title.</value>
		string Title { get; set; }

		/// <summary>
		/// Gets or sets the list of collections attached to this workspace.
		/// </summary>
		/// <value>The list of collections.</value>
		IList<IAtomCollection> Collections { get; set; }

		/// <summary>
		/// Gets or sets the repository info.
		/// </summary>
		/// <value>The repository info.</value>
		ICmisRepositoryInfo RepositoryInfo { get; set; }

		/// <summary>
		/// Gets or sets the links.
		/// </summary>
		/// <value>The links.</value>
		IList<IAtomLink> Links { get; set; }

		/// <summary>
		/// Gets or sets the URI templates.
		/// </summary>
		/// <value>The URI templates.</value>
		IList<IAtomUriTemplate> UriTemplates { get; set; }
	}
}
