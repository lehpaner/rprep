using System.Collections.Generic;

namespace RufaPoint.Cmis.Infrastructure.Interfaces
{
	/// <summary>
	/// CMIS choice. Represents a choice value of a CMIS property.
	/// </summary>
    /// <typeparam name="T">The type of the choice value.</typeparam>
	public interface ICmisChoice<T>
    {
        /// <summary>
        /// Gets the display name.
        /// </summary>
        /// <value>The display name.</value>
        string DisplayName { get; }

        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <value>The value.</value>
        IList<T> Value { get; }

        /// <summary>
        /// Gets the children of the choice value.
        /// </summary>
        /// <value>The children.</value>
        IList<ICmisChoice<T>> Children { get; }
    }
}
