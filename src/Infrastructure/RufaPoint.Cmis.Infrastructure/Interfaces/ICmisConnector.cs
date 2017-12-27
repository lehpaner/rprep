
namespace RufaPoint.Cmis.Infrastructure.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// CMIS connector. Provides members for CMIS services.
    /// </summary>
    public interface ICmisConnector : ICmisExtensionData
    {
        /// <summary>
        /// Gets or sets the service root URI. 
        /// </summary>
        /// <value>The service root.</value>
        string ServiceRoot { get; set; }

        /// <summary>
        /// Gets the list of repositories.
        /// </summary>
        /// <returns>The repositories list.</returns>
        Task<IList<ICmisRepositoryShortInfo>> GetRepositoriesAsync();

        /// <summary>
        /// Gets the repository info for a specific CMIS repository.
        /// </summary>
        /// <returns>The repository info.</returns>
        /// <param name="repositoryId">Repository identifier.</param>
        Task<ICmisRepositoryInfo> GetRepositoryInfoAsync(string repositoryId);

		/// <summary>
		/// Gets the AtomPub Service Document that contains the set of repositories that are available. Can be filtered to return only informations for one repository. See http://docs.oasis-open.org/cmis/CMIS/v1.1/os/CMIS-v1.1-os.html#x1-4280007
		/// </summary>
		/// <returns>The Atom service document.</returns>
		/// <param name="repositoryId">Repository identifier. When not set, informations about all repositories are returned. Defaults to null.</param>
		Task<IAtomService> GetServiceDocument(string repositoryId = null);
    }
}
