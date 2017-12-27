

namespace RufaPoint.Cmis.Infrastructure.Enums
{
	/// <summary>
	/// CMIS ACL progagation. Speciﬁes how non-direct ACEs can be handled by the repository.
	/// </summary>
	public enum CmisAclProgagation
    {
		/// <summary>
		/// Indicates that the repository is able to apply ACEs to an object without changing the ACLs of other objects..
		/// </summary>
		[CmisName(Constants.CmisAclPropagationObjectOnly)]
        ObjectOnly,
		/// <summary>
		/// Indicates that the ACEs might be inherited by other objects. propagate includes the support for objectonly.
		/// </summary>
		[CmisName(Constants.CmisAclPropagationPropagate)]
        Propagate,
		/// <summary>
		/// Indicates that the repository has its own mechanism of computing how changing an ACL for an object inﬂuences the non-direct ACEs of other objects.
		/// </summary>
		[CmisName(Constants.CmisAclRepositoryDetermined)]
        RepositoryDetermined
    }
}
