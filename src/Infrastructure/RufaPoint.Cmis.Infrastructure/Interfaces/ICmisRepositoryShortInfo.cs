
using System;
namespace RufaPoint.Cmis.Infrastructure.Interfaces
{
    /// <summary>
    /// CMIS repository info containing only identifier and name. 
    /// </summary>
    public interface ICmisRepositoryShortInfo : ICmisExtensionData
    {
		/// <summary>
		/// Gets the CMIS repository identifier.
		/// </summary>
		/// <value>The identifier.</value>
		string RepositoryId { get; }

		/// <summary>
		/// Gets the CMIS repository display name.
		/// </summary>
		/// <value>The display name.</value>
		string RepositoryName { get; }

        /// <summary>
        /// Gets the CMIS repository URL.
        /// </summary>
        /// <value>The repository URL.</value>
        string RepositoryUrl { get; }

        /// <summary>
        /// Gets the CMIS repository root folder URL.
        /// </summary>
        /// <value>The root folder URL.</value>
        string RootFolderUrl { get; }
    }
}
