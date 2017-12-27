using RufaPoint.Cmis.Infrastructure.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RufaPoint.Cmis.Infrastructure.Services
{
    /// <summary>
    /// CMIS Repository service.
    /// </summary>
    public interface ICmisRepositoryService
    {
        /// <summary>
        /// Gets or sets the service root URI. 
        /// </summary>
        /// <value>The service root.</value>
        string ServiceRoot { get; set; }

        /// <summary>
        /// Returns a list of CMIS repositories available from this CMIS service endpoint.
        /// </summary>
        /// <returns>The list of repository identifiers and names.</returns>
        Task<IList<ICmisRepositoryShortInfo>> GetRepositoriesAsync();

        /// <summary>
        /// Returns information about the CMIS repository, the optional capabilities it supports and its access control information if applicable.
        /// </summary>
        /// <returns>The repository info.</returns>
        /// <param name="repositoryId">Repository identifier.</param>
        Task<ICmisRepositoryInfo> GetRepositoryInfoAsync(string repositoryId);

        /// <summary>
        /// Gets the AtomPub Service Document that contains the set of repositories that are available. See http://docs.oasis-open.org/cmis/CMIS/v1.1/os/CMIS-v1.1-os.html#x1-4280007
        /// </summary>
        /// <returns>The Atom service document.</returns>
        /// <param name="repositoryId">Repository identifier. When not set, informations about all repositories are returned. Defaults to null.</param>
        Task<IAtomService> GetServiceDocumentAsync(string repositoryId = null);
    }
}
