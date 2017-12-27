

namespace RufaPoint.Cmis.Infrastructure.Interfaces
{
	/// <summary>
	/// CMIS folder object-type definition.
	/// A folder object serves as the anchor for a collection of ﬁle-able objects. 
	/// The folder object has an implicit hierarchical relationship with each object 
	/// in its collection, with the anchor folder object being the parent object and 
	/// each object in the collection being a child object. This implicit relationship 
	/// has speciﬁc containment semantics which MUST be maintained by the repository 
	/// with implicit referential integrity. (That is, there will never be a dangling 
	/// parent-relationship or a dangling child-relationship. Furthermore, object A 
	/// is a parent of object B if and only if object B is a child of object A.) 
	/// This system-maintained implicit relationship is distinct from an explicit 
	/// relationship which is instantiated by an application-maintained relationship object. 
	/// (See section 2.1.6 Relationship Object.) A folder object does not have a 
	/// content-stream and is not version-able.A folder object MAY be associated with 
	/// zero or more renditions(see section 2.1.4.2 Renditions).
	/// </summary>
	public interface ICmisFolderTypeDefinition : ICmisTypeDefinition
    {
    }
}
