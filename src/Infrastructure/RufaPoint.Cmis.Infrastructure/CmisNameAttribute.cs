using System;
using System.Collections.Generic;
using System.Text;

namespace RufaPoint.Cmis.Infrastructure
{
    /// <summary>
    /// CMIS name attribute. Adds the corresponding CMIS compliant name to a class, property, field or enumeration value.
    /// </summary>
    public class CmisNameAttribute : Attribute
    {
        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Cmis.Infrastructure.CmisNameAttribute"/> class.
        /// </summary>
        /// <param name="name">Name.</param>
        public CmisNameAttribute(string name)
        {
            Name = name;
        }
    }
}
