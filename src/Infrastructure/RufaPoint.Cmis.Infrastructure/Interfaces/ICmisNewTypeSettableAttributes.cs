
namespace RufaPoint.Cmis.Infrastructure.Interfaces
{
    /// <summary>
    /// CMIS settable attributes when creating new types. 
    /// </summary>
    public interface ICmisNewTypeSettableAttributes : ICmisExtensionData
    {
        /// <summary>
        /// Gets a value indicating whether the identifier attribute can be set when creating new CMIS types.
        /// </summary>
        /// <value><c>true</c> if the attribute can be set; otherwise, <c>false</c>.</value>
        bool Id { get; }

		/// <summary>
		/// Gets a value indicating whether the local name attribute can be set when creating new CMIS types.
		/// </summary>
		/// <value><c>true</c> if the attribute can be set; otherwise, <c>false</c>.</value>
		bool LocalName { get; }

		/// <summary>
		/// Gets a value indicating whether the local namespace attribute can be set when creating new CMIS types.
		/// </summary>
		/// <value><c>true</c> if the attribute can be set; otherwise, <c>false</c>.</value>
		bool LocalNamespace { get; }

		/// <summary>
		/// Gets a value indicating whether the display name attribute can be set when creating new CMIS types.
		/// </summary>
		/// <value><c>true</c> if the attribute can be set; otherwise, <c>false</c>.</value>
		bool DisplayName { get; }

		/// <summary>
		/// Gets a value indicating whether the query name attribute can be set when creating new CMIS types.
		/// </summary>
		/// <value><c>true</c> if the attribute can be set; otherwise, <c>false</c>.</value>
		bool QueryName { get; }

		/// <summary>
		/// Gets a value indicating whether the description attribute can be set when creating new CMIS types.
		/// </summary>
		/// <value><c>true</c> if the attribute can be set; otherwise, <c>false</c>.</value>
		bool Description { get; }

		/// <summary>
		/// Gets a value indicating whether the creatable attribute can be set when creating new CMIS types.
		/// </summary>
		/// <value><c>true</c> if the attribute can be set; otherwise, <c>false</c>.</value>
		bool Createable { get; }

		/// <summary>
		/// Gets a value indicating whether the fileable attribute can be set when creating new CMIS types.
		/// </summary>
		/// <value><c>true</c> if the attribute can be set; otherwise, <c>false</c>.</value>
		bool Fileable { get; }

		/// <summary>
		/// Gets a value indicating whether the queryable attribute can be set when creating new CMIS types.
		/// </summary>
		/// <value><c>true</c> if the attribute can be set; otherwise, <c>false</c>.</value>
		bool Queryable { get; }

		/// <summary>
		/// Gets a value indicating whether the fulltext indexed attribute can be set when creating new CMIS types.
		/// </summary>
		/// <value><c>true</c> if the attribute can be set; otherwise, <c>false</c>.</value>
		bool FulltextIndexed { get; }

		/// <summary>
		/// Gets a value indicating whether the included in supertype query attribute can be set when creating new CMIS types.
		/// </summary>
		/// <value><c>true</c> if the attribute can be set; otherwise, <c>false</c>.</value>
		bool IncludedInSupertypeQuery { get; }

		/// <summary>
		/// Gets a value indicating whether the controllable policy attribute can be set when creating new CMIS types.
		/// </summary>
		/// <value><c>true</c> if the attribute can be set; otherwise, <c>false</c>.</value>
		bool ControllablePolicy { get; }

		/// <summary>
		/// Gets a value indicating whether the controllable ACL attribute can be set when creating new CMIS types.
		/// </summary>
		/// <value><c>true</c> if the attribute can be set; otherwise, <c>false</c>.</value>
		bool ControllableACL { get; }
    }
}
