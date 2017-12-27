namespace RufaPoint.Cmis.Model
{
    using System.Collections.Generic;
    using RufaPoint.Cmis.Infrastructure.Interfaces;
    using RufaPoint.Cmis.Infrastructure.Enums;

    /// <summary>
    /// CMIS repository capability.
    /// Commercial ECM repositories vary in their designs. Moreover, some 
    /// repositories are designed for a speciﬁc application domain and may not 
    /// provide certain capabilities that are not needed for their targeted 
    /// domain. Thus, a repository implementation may not necessarily be able to 
    /// support all CMIS capabilities. A few CMIS capabilities are therefore 
    /// "optional" for a repository to be compliant. A repository’s support for 
    /// each of these optional capabilities is discoverable using the 
    /// getRepositoryInfo service. 
    /// </summary>
    public class CmisRepositoryCapabilities : ICmisRepositoryCapabilities
    {
		/// <summary>
		/// Gets or sets a value indicating whether the repository has the ability to enumerate the descendants of a folder via the getDescendants service.
		/// </summary>
		/// <value><c>true</c> if get descendants is supported; otherwise, <c>false</c>.</value>
		public bool? CapabilityGetDescendants { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether this repository has the ability to retrieve the folder tree via the getFolderTree service..
		/// </summary>
		/// <value><c>true</c> if capability get folder tree is supported; otherwise, <c>false</c>.</value>
		public bool? CapabilityGetFolderTree { get; set; }

		/// <summary>
		/// Gets or sets a value indicating the ordering capabilities of the repository.
		/// </summary>
		/// <value>The order by capability.</value>
		public CmisCapabilityOrderBy? CapabilityOrderBy { get; set; }

		/// <summary>
		/// Gets or sets a value indicating the support a repository has for updating a documents content stream.
		/// </summary>
		/// <value>The content stream update capoability.</value>
		public CmisCapabilityContentStreamUpdatability? CapabilityContentStreamUpdatability { get; set; }

		/// <summary>
		/// Gets or sets a value indicating what level of changes (if any) the repository exposes via the getContentChanges service.
		/// </summary>
		/// <value>The changes capability.</value>
		public CmisCapabilityChanges? CapabilityChanges { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether or not the repository exposes renditions of document or folder objects.
		/// </summary>
		/// <value>The renditions capability.</value>
		public CmisCapabilityRenditions? CapabilityRenditions { get; set; }

		/// <summary>
		/// Gets or sets a value indicating the ability for an application to ﬁle a document or other ﬁle-able object in more than one folder.
		/// </summary>
		/// <value><c>true</c> if multifiling is supported; otherwise, <c>false</c>.</value>
		public bool? CapabilityMultiﬁling { get; set; }

		/// <summary>
		/// Gets or sets a value indicating the ability for an application to leave a document or other ﬁle-able object not ﬁled in any folder.
		/// </summary>
		/// <value><c>true</c> if unfiling is supported; otherwise, <c>false</c>.</value>
		public bool? CapabilityUnﬁling { get; set; }

		/// <summary>
		/// Gets or sets the capability version speciﬁc filing.
		/// </summary>
		/// <value><c>true</c> if version specific filing is supported; otherwise, <c>false</c>.</value>
		public bool? CapabilityVersionSpeciﬁcFiling { get; set; }

		/// <summary>
		/// Gets or sets a value indicating the ability for an application to update the "Private Working Copy" of a checked-out document.
		/// </summary>
		/// <value><c>true</c> if private working copy update is supported; otherwise, <c>false</c>.</value>
		public bool? CapabilityPWCUpdatable { get; set; }

		/// <summary>
		/// Gets or sets a value indicating the ability of the Repository to include the "Private Working Copy" of checked-out documents in query search scope; otherwise PWC’s are not searchable.
		/// </summary>
		/// <value><c>true</c> if private working copy search is supported; otherwise, <c>false</c>.</value>
		public bool? CapabilityPWCSearchable { get; set; }

		/// <summary>
		/// Gets or sets a value indicating the ability of the Repository to include all versions of a document. If False, typically either the latest or the latest major version will be searchable.
		/// </summary>
		/// <value><c>true</c> if all document versions search is supported; otherwise, <c>false</c>.</value>
		public bool? CapabilityAllVersionsSearchable { get; set; }

		/// <summary>
		/// Gets or sets a value indicating the types of queries that the Repository has the ability to fulﬁll.
		/// </summary>
		/// <value>The query capability.</value>
		public CmisCapabilityQuery? CapabilityQuery { get; set; }

		/// <summary>
		/// Gets or sets a value indicating the types of JOIN keywords that the Repository can fulﬁll in queries.
		/// </summary>
		/// <value>The join capability.</value>
		public CmisCapabilityJoin? CapabilityJoin { get; set; }

		/// <summary>
		/// Gets or sets the list of all property data types that can be used by a client to create or update an object-type deﬁnition.
		/// </summary>
		/// <value>The capability creatable property types.</value>
		public ICmisCreateablePropertyTypes CapabilityCreatablePropertyTypes { get; set; }

		/// <summary>
		/// Gets or sets which object-type attributes can be set by a client when a new object-type is created.
		/// </summary>
		/// <value>The new type settable attributes capability.</value>
		public ICmisNewTypeSettableAttributes CapabilityNewTypeSettableAttributes { get; set; }

		/// <summary>
		/// Gets or sets a value indicating the level of support for ACLs by the repository.
		/// </summary>
		/// <value>The capability acl.</value>
		public CmisCapabilityACL? CapabilityACL { get; set; }

		/// <summary>
		/// Gets or sets the list of CMIS extensions.
		/// </summary>
		/// <value>The list of CMIS extensions.</value>
		public IList<ICmisExtensionElement> Extensions { get; set; }
    }
}
