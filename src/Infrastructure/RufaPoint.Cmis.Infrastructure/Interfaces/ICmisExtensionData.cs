

namespace RufaPoint.Cmis.Infrastructure.Interfaces
{
    using System.Collections.Generic;

    /// <summary>
    /// CMIS extension data. Holds a list of <see cref="ICmisExtensionElement"/> instances that represent optional extension data to the CMIS specification.
    /// </summary>
    public interface ICmisExtensionData
    {
        /// <summary>
        /// Gets or sets the list of CMIS extensions.
        /// </summary>
        /// <value>The list of CMIS extensions.</value>
        IList<ICmisExtensionElement> Extensions { get; set; }
    }
}
