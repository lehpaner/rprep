﻿
namespace RufaPoint.Cmis.Model
{
    using RufaPoint.Cmis.Infrastructure.Interfaces;
    using System.Collections.Generic;


	/// <summary>
	/// CMIS repository feature. Repositories MAY provide information about additional features that are supported by the repository but that are outside the CMIS speciﬁcation. This information is returned by the getRepositoryInfo service.
	/// </summary>
	public class CmisRepositoryFeature : ICmisRepositoryFeature
    {
		/// <summary>
		/// Gets or sets the unique identifier of the feature. It SHOULD take the form of a URI (see [RFC3986]).
		/// </summary>
		/// <value>The feature identifier.</value>
		public string Id { get; set; }

		/// <summary>
		/// Gets or sets the URL of the feature.
		/// </summary>
		/// <value>The CMIS feature URL.</value>
		public string Url { get; set; }

		/// <summary>
		/// Gets or sets the feature version label.
		/// </summary>
		/// <value>The version label.</value>
		public string VersionLabel { get; set; }

		/// <summary>
		/// Gets or sets the human readable feature name.
		/// </summary>
		/// <value>The feature name.</value>
		public string CommonName { get; set; }

		/// <summary>
		/// Gets or sets the feature description.
		/// </summary>
		/// <value>The description.</value>
		public string Description { get; set; }

		/// <summary>
		/// Gets or sets the feature data as a dictionary of key-value pairs. The semantics and rules for these key-value pairs are not deﬁned by CMIS but MAY be constrained by other speciﬁcations.
		/// </summary>
		/// <value>The data.</value>
		public IDictionary<string, string> Data { get; set; }

		/// <summary>
		/// Gets or sets the list of CMIS extensions.
		/// </summary>
		/// <value>The list of CMIS extensions.</value>
		public IList<ICmisExtensionElement> Extensions { get; set; }
    }
}
