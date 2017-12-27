

namespace RufaPoint.Cmis.Infrastructure.Enums
{
    /// <summary>
    /// CMIS base type identifier.
    /// </summary>
    public enum CmisBaseTypeId
    {
        /// <summary>
        /// CMIS document type.
        /// </summary>
        [CmisName(Constants.CmisDocument)]
        CmisDocument,

        /// <summary>
        /// CMIS folder type.
        /// </summary>
        [CmisName(Constants.CmisFolder)]
        CmisFolder,

        /// <summary>
        /// CMIS relationship type.
        /// </summary>
        [CmisName(Constants.CmisRelationship)]
        CmisRelationship,

        /// <summary>
        /// CMIS policy type.
        /// </summary>
        [CmisName(Constants.CmisPolicy)]
        CmisPolicy,

        /// <summary>
        /// CMIS item type.
        /// </summary>
        [CmisName(Constants.CmisItem)]
        CmisItem,

        /// <summary>
        /// CMIS secondary type.
        /// </summary>
        [CmisName(Constants.CmisSecondary)]
        CmisSecondary
    }
}
