
using RufaPoint.Cmis.Infrastructure.Interfaces;

namespace RufaPoint.Cmis.Model
{
	/// <summary>
	/// CMIS policy type definition.
	/// A policy object represents an administrative policy that can be enforced 
	/// by a repository. CMIS does not specify what kinds of administrative policies 
	/// that are speciﬁcally supported, nor attempts to model administrative policy 
	/// of any particular kind. Only a base object-type is speciﬁed for policy objects. 
	/// Each policy object holds the text of an administrative policy as a 
	/// repository-speciﬁc string, which is opaque to CMIS and which may be used 
	/// to support policies of various kinds. A repository may create subtypes of 
	/// this base type to support diﬀerent kinds of administrative policies more 
	/// speciﬁcally. If a repository does not support policy objects, the policy 
	/// base object-type SHOULD NOT be returned by a getTypeChildren service call. 
	/// This is an extension point for repositories that want to expose other 
	/// capabilities via CMIS that are not supported directly in CMIS.
	/// </summary>
	public class CmisPolicyTypeDefinition : CmisTypeDefinitionBase, ICmisPolicyTypeDefinition
    {
    }
}
