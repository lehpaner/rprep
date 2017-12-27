

namespace RufaPoint.Cmis.Infrastructure.Interfaces
{
	/// <summary>
	/// CMIS secondary type definition.
	/// A secondary type deﬁnes a set of properties that can be dynamically added to and removed from objects. That is, an object can get and lose additional properties that are not deﬁned by its primary type during its lifetime. Multiple secondary types can be applied to the same object at the same time. Secondary types can be simple markers without properties.Alternatively, they can contain technical information about an object. For example, a repository might analyze the content of a document, detects a photo and adds a secondary type that adds EXIF data to the document.Applications might want to attach temporary data to an object such the state of the object in a workﬂow. Secondary types may also change the behaviour of the repository.
	/// </summary>
	public interface ICmisSecondaryTypeDefinition : ICmisTypeDefinition
    {
    }
}
