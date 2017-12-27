﻿//
// CmisPropertyDefinition.cs
//
// Author:
//       Dannys Janssen

using RufaPoint.Cmis.Infrastructure.Enums;
using RufaPoint.Cmis.Infrastructure.Interfaces;

namespace RufaPoint.Cmis.Model
{
	/// <summary>
	/// CMIS property definition base class. All object-type property deﬁnitions MUST contain the following attributes. Optional attributes MUST be deﬁned but MAY have "not set" values.
	/// Choices and DefaultValue attributes as specified in the CMIS specs must be defined in inheriting classes.
	/// </summary>
	public abstract class CmisPropertyDefinition : CmisExtensionData, ICmisPropertyDefinition
    {
		/// <summary>
		/// This opaque attribute uniquely identiﬁes the property in the repository. If two object-types each contain property deﬁnitions with the same id, the basic property deﬁnitions (property type, query name, cardinality) MUST be the same. Other attributes MAY be diﬀerent for each type.
		/// </summary>
		/// <value>The identifier.</value>
        public string Id { get; set; }

		/// <summary>
		/// This attribute represents the underlying repository’s name for the property. This ﬁeld is opaque and has no uniqueness constraint imposed by this speciﬁcation.
		/// </summary>
		/// <value>The name of the local.</value>
		public string LocalName { get; set; }

		/// <summary>
		/// This attribute allows repositories to represent the internal namespace of the underlying repository’s name for the property.
		/// </summary>
		/// <value>The local namespace.</value>
		public string LocalNamespace { get; set; }

		/// <summary>
		/// Used for query operations on properties. This is an opaque string with limitations. See CMIS specs section 2.1.2.1.3 Query Names for details.
		/// </summary>
		/// <value>The name of the query.</value>
		public string QueryName { get; set; }

		/// <summary>
		/// Used for presentation by application.
		/// </summary>
		/// <value>The display name.</value>
		public string DisplayName { get; set; }

		/// <summary>
		/// This is an optional attribute containing a description of the property.
		/// </summary>
		/// <value>The description.</value>
		public string Description { get; set; }

		/// <summary>
		/// This attribute indicates the type of this property. It MUST be one of the allowed property types. (See CMIS specs section 2.1.2.1 Property.)
		/// </summary>
		/// <value>The type of the property.</value>
		public CmisPropertyType PropertyType { get; set; }

		/// <summary>
		/// Indicates whether the property can have "zero or one" or "zero or more" values.
		/// </summary>
		/// <value>The cardinality.</value>
		public CmisCardinality? Cardinality { get; set; }

		/// <summary>
		/// Indicates under what circumstances the value of this property MAY be updated.
		/// </summary>
		/// <value>The updatability.</value>
		public CmisUpdatability? Updatability { get; set; }

		/// <summary>
		/// Indicates whether the property deﬁnition is inherited from the parent type when TRUE or it is explicitly deﬁned for this object-type when FALSE.
		/// </summary>
		/// <value>The inherited.</value>
		public bool? Inherited { get; set; }

		/// <summary>
		/// This attribute is only applicable to non-system properties, i.e. properties whose value is provided by the application.
		/// If TRUE, then the value of this property MUST never be set to the "not set" state when an object of this type is created/updated.If not provided during a create or update operation, the repository MUST provide a value for this property.If a value is not provided, then the default value deﬁned for the property MUST be set.If no default value is provided and no default value is deﬁned, the repository MUST throw a constraint exception.
		/// This attribute is not applicable when the "updatability" attribute is "readonly". In that case, "required" SHOULD be set to FALSE.
		/// </summary>
		/// <value>The required.</value>
		/// <remarks>For CMIS-deﬁned object-types, the value of a system property (such as cmis:objectId, cmis:createdBy) MUST be set by the repository. However, the property’s "required" attribute SHOULD be FALSE because it is read-only to applications.</remarks>
		public bool? Required { get; set; }

		/// <summary>
		/// Indicates whether or not the property MAY appear in the WHERE clause of a CMIS query statement.
		/// This attribute MUST have a value of FALSE if the object-type’s attribute for "queryable" is set to FALSE.
		/// </summary>
		/// <value>The queryable.</value>
		public bool? Queryable { get; set; }

		/// <summary>
		/// Indicates whether the property can appear in the ORDER BY clause of a CMIS query statement or an orderBy 
		/// parameter of getChildren or getCheckedOutDocs.
		/// This property MUST be FALSE for any property whose cardinality is "multi".
		/// </summary>
		/// <value>The orderable.</value>
		public bool? Orderable { get; set; }

		/// <summary>
		/// This attribute is only applicable to properties that provide a value for the "Choices" attribute.
		/// If FALSE, then the data value for the property MUST only be one of the values speciﬁed in the "Choices" attribute. 
		/// If TRUE, then values other than those included in the "Choices" attribute may be set for the property.
		/// </summary>
		/// <value>The open choice.</value>
		public bool? OpenChoice { get; set; }
    }
}
