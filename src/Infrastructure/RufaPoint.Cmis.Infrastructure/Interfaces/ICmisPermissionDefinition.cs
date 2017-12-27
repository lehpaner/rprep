
namespace RufaPoint.Cmis.Infrastructure.Interfaces
{
    /// <summary>
    /// CMIS permission definition.
    /// </summary>
    public interface ICmisPermissionDefinition : ICmisExtensionData
    {
        /// <summary>
        /// Gets the CMIS permission name.
        /// </summary>
        /// <value>The CMIS permission name.</value>
        string Permission { get; }

        /// <summary>
        /// Gets the CMIS permission description.
        /// </summary>
        /// <value>The CMIS permission description.</value>
        string Description { get; }
    }
}
