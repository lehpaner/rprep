
namespace RufaPoint.Cmis.Infrastructure.Interfaces
{
    using System.Collections.Generic;

	/// <summary>
	/// CMIS repository feature. Repositories MAY provide information about additional features that are supported by the repository but that are outside the CMIS speciﬁcation. This information is returned by the getRepositoryInfo service.
	/// </summary>
	public interface ICmisRepositoryFeature : ICmisExtensionData
    {
		/// <summary>
		/// Gets the unique identifier of the feature. It SHOULD take the form of a URI (see [RFC3986]).
		/// </summary>
		/// <value>The feature identifier.</value>
		string Id { get; }

        /// <summary>
        /// Gets the URL of the feature.
        /// </summary>
        /// <value>The CMIS feature URL.</value>
        string Url { get; }

        /// <summary>
        /// Gets the feature version label.
        /// </summary>
        /// <value>The version label.</value>
        string VersionLabel { get; }

        /// <summary>
        /// Gets the human readable feature name.
        /// </summary>
        /// <value>The feature name.</value>
        string CommonName { get; }

        /// <summary>
        /// Gets the feature description.
        /// </summary>
        /// <value>The description.</value>
        string Description { get; }

		/// <summary>
		/// Gets the feature data as a dictionary of key-value pairs. The semantics and rules for these key-value pairs are not deﬁned by CMIS but MAY be constrained by other speciﬁcations.
		/// </summary>
		/// <value>The data.</value>
		IDictionary<string, string> Data { get; }
    }
}
