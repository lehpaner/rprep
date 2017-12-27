
namespace RufaPoint.Cmis.Model
{
    using RufaPoint.Cmis.Infrastructure.Interfaces;
    using System;
    using System.Collections.Generic;

	/// <summary>
	/// CMIS repository info containing only identifier and name.
	/// </summary>
	public class CmisRepositoryShortInfo : ICmisRepositoryShortInfo
    {
		/// <summary>
		/// Gets the CMIS repository identifier.
		/// </summary>
		/// <value>The identifier.</value>
		public string RepositoryId { get; set; }

		/// <summary>
		/// Gets the CMIS repository display name.
		/// </summary>
		/// <value>The display name.</value>
		public string RepositoryName { get; set; }

        /// <summary>
        /// Gets or sets the repository URL.
        /// </summary>
        /// <value>The repository URL.</value>
        public string RepositoryUrl { get; set; }

		/// <summary>
		/// Gets the CMIS repository URL.
		/// </summary>
		/// <value>The repository URL.</value>
		public string RootFolderUrl { get; set; }

		/// <summary>
		/// Gets or sets the list of CMIS extensions.
		/// </summary>
		/// <value>The list of CMIS extensions.</value>
		public IList<ICmisExtensionElement> Extensions { get; set; }
    }
}
