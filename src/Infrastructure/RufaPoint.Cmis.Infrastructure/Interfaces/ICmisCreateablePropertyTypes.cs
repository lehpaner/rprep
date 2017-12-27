﻿

namespace RufaPoint.Cmis.Infrastructure.Interfaces
{
    using RufaPoint.Cmis.Infrastructure.Enums;
    using System.Collections.Generic;

	/// <summary>
	/// CMIS createable property types. 
    /// A list of all property data types that can be used by a client to create 
    /// or update an object-type deﬁnition.
    /// 
	/// A property MAY hold zero, one, or more typed data value(s). 
	/// Each property MAY be single-valued or multi-valued. 
	/// A single-valued property contains a single data value, whereas a 
	/// multi-valued property contains an ordered list of data values of the 
	/// same type. The ordering of values in a multi-valued property SHOULD be 
	/// preserved by the repository.!----> property, either single-valued or 
	/// multi-valued, MAY be in a "not set" state.CMIS does not support "null" 
	/// property value.If a multi-valued property is not in a "not set" state, 
	/// its property value MUST be a non-empty list of individual values.Each 
	/// individual value in the list MUST NOT be in a "not set" state and MUST 
	/// conform to the property’s property-type. A multi-valued property is 
	/// either set or not set in its entirety. An individual value of a 
	/// multi-valued property MUST NOT be in an individual "value not set" 
	/// state and hold a position in the list of values. An empty list of values 
	/// MUST NOT be allowed. Every property is typed.The property-type deﬁnes 
	/// the data type of the data value(s) held by the property.CMIS speciﬁes 
	/// the following property-types.
	/// </summary>
    public interface ICmisCreateablePropertyTypes : ICmisExtensionData
    {
		/// <summary>
		/// Gets the list of all property data types that can be used by a client to create 
		/// or update an object-type deﬁnition.
		/// </summary>
		/// <value>The list of createable proerty types.</value>
		ISet<CmisPropertyType> CanCreate { get; }
    }
}
