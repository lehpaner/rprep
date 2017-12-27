﻿
using RufaPoint.Cmis.Infrastructure.Interfaces;

namespace RufaPoint.Cmis.Model
{
	/// <summary>
	/// CMIS item type definition.
	/// The item object is an extension point for repositories that want to 
	/// expose other object types via CMIS that do not ﬁt the deﬁnition for 
	/// document, folder, relationship or policy. For example an independently 
	/// persistable collection of properties that was not versionable and did 
	/// not have content. Another example could be a base identity object for 
	/// users and groups.
	/// </summary>
	public class CmisItemTypeDefinition : CmisTypeDefinitionBase, ICmisItemTypeDefinition
    {
    }
}
