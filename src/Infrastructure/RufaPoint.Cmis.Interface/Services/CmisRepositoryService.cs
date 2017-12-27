using RufaPoint.Cmis.Infrastructure.Interfaces;
using RufaPoint.Cmis.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RufaPoint.Cmis.Interface.Services
{
    /// <summary>
    /// CMIS Repository service.
    /// </summary>
    public class CmisRepositoryService : ICmisRepositoryService
    {
        #region Properties

        /// <summary>
        /// Gets or sets the service root URI. 
        /// </summary>
        /// <value>The service root.</value>
        public string ServiceRoot { get; set; }

        /// <summary>
        /// Gets the CMIS connector instance.
        /// </summary>
        /// <value>The CMIS connector instance.</value>
        public ICmisConnector Connector { get; private set; }

        #endregion

        #region ctor

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Cmis.Interface.CmisRepositoryService"/> class.
        /// </summary>
        /// <param name="connector">The CMIS connector isntance.</param>
        public CmisRepositoryService(ICmisConnector connector)
        {
            Connector = connector;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Returns a list of CMIS repositories available from this CMIS service endpoint.
        /// </summary>
        /// <returns>The list of repository identifiers and names.</returns>
        public async Task<IList<ICmisRepositoryShortInfo>> GetRepositoriesAsync()
        {
            Connector.ServiceRoot = ServiceRoot;
            return await Connector.GetRepositoriesAsync();
        }

        /// <summary>
        /// Returns information about the CMIS repository, the optional capabilities it supports and its access control information if applicable.
        /// </summary>
        /// <returns>The repository info.</returns>
        /// <param name="repositoryId">Repository identifier.</param>
        public async Task<ICmisRepositoryInfo> GetRepositoryInfoAsync(string repositoryId)
        {
            Connector.ServiceRoot = ServiceRoot;
            return await Connector.GetRepositoryInfoAsync(repositoryId);
        }

        /// <summary>
        /// Gets the AtomPub Service Document that contains the set of repositories that are available. See http://docs.oasis-open.org/cmis/CMIS/v1.1/os/CMIS-v1.1-os.html#x1-4280007
        /// </summary>
        /// <returns>The Atom service document.</returns>
        /// <param name="repositoryId">Repository identifier. When not set, informations about all repositories are returned. Defaults to null.</param>
        public async Task<IAtomService> GetServiceDocumentAsync(string repositoryId = null)
        {
            Connector.ServiceRoot = ServiceRoot;
            return await Connector.GetServiceDocument(repositoryId);
        }

        #endregion
    }
}
