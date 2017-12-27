

namespace RufaPoint.Cmis.Infrastructure.Enums
{
	/// <summary>
	/// CMIS updatability. Indicates under what circumstances the value of a property MAY be updated.
	/// </summary>
	public enum CmisUpdatability
    {
		/// <summary>
		/// The value of this property MUST NOT ever be set directly by an application. 
        /// It is a system property that is either maintained or computed by the repository. 
        /// The value of a read-only property MAY be indirectly modiﬁed by other repository interactions 
        /// (for example, calling updateProperties on an object will change the object’s last modiﬁed date, 
        /// even though that property cannot be directly set via an updateProperties service call.) 
		/// </summary>
        [CmisName(Constants.CmisUpdatabilityReadOnly)]
		ReadOnly,
		/// <summary>
		/// The property value can be modiﬁed using the updateProperties service.
		/// </summary>
        [CmisName(Constants.CmisUpdatabilityReadWrite)]
		ReadWrite,
		/// <summary>
		/// The property value MUST only be update-able using a "private working copy" document. That is, the update is either made on a "private working copy" object or made using the checkIn service.
		/// </summary>
        [CmisName(Constants.CmisUpdatabilityWhenCheckedOut)]
		WhenCheckedOut,
		/// <summary>
		/// The property value MUST only be update-able during the create operation on that object.
		/// </summary>
        [CmisName(Constants.CmisUpdatabilityOnCreate)]
		OnCreate
    }
}
