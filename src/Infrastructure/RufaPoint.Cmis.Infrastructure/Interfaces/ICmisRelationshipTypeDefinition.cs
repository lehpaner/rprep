
using System.Collections.Generic;

namespace RufaPoint.Cmis.Infrastructure.Interfaces
{
	/// <summary>
	/// CMIS relationship type definition.
	/// A relationship object instantiates an explicit, binary, directional, 
	/// non-invasive, and typed relationship between a source object and a target 
	/// object. The source object and the target object MUST both be independent 
	/// objects, such as a document object, a folder object, a policy object, or 
	/// an item object. Whether a policy object is allowed to be the source or 
	/// target object of a relationship object is repository-speciﬁc.
	/// </summary>
	public interface ICmisRelationshipTypeDefinition : ICmisTypeDefinition
    {
		/// <summary>
		/// A list of object-type ids, indicating that the source object of a 
		/// relationship object of this type MUST only be one of the types listed. 
		/// If this attribute is "not set", then the source object MAY be of any type.
		/// </summary>
		/// <value>The list of allowed source types.</value>
		IList<ICmisObjectType> AllowedSourceTypes { get; }

		/// <summary>
		/// A list of object-type ids, indicating that the target object of a 
		/// relationship object of this type MUST only be one of the types listed. 
		/// If this attribute is "not set", then the target object MAY be of any type.
		/// </summary>
		/// <value>The list of allowed target types.</value>
		IList<ICmisObjectType> AllowedTargetTypes { get; }
    }
}
