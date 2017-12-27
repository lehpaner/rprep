
namespace RufaPoint.Cmis.Infrastructure.Interfaces
{
    using System.Collections.Generic;

	/// <summary>
	/// CMIS permission mapping.
	/// Since several allowable actions require permissions on more than one 
	/// object, the mapping table is deﬁned in terms of permission "keys". 
	/// (For example, moving a document from one folder to another may 
	/// require permissions on the document and each of the folders.) 
	/// Each key combines the name of the allowable action and the object 
	/// for which the principal needs the required permission. For example, 
	/// the canMoveObject.Source key indicates the permissions that the 
	/// principal must have on the "source folder" to move an object from 
	/// that folder into another folder.
	/// </summary>
	public interface ICmisPermissionMapping : ICmisExtensionData
    {
		/// <summary>
		/// Gets the permission key name.
        /// </summary>
        /// <value>The permission key.</value>
        string Key { get; }

		/// <summary>
		/// The name of one or more permissions that the principal MUST have. If more than one permission is speciﬁed, then the principal MUST be allowed to perform the operation if they have ANY of the listed permissions.
		/// </summary>
		/// <value>The list of permission names.</value>
		IList<string> Permission { get; }
    }
}
