
using System.Collections.Generic;

namespace RufaPoint.Cmis.Infrastructure.Interfaces
{
    /// <summary>
    /// CMIS object type. Base type for all CMIS objects.
    /// </summary>
    public interface ICmisObjectType : ICmisTypeDefinition
    {
        /// <summary>
        /// Gets a value indicating whether this <see cref="T:Cmis.Infrastructure.ICmisObjectType"/> is a base type.
        /// </summary>
        /// <value><c>true</c> if is a base type; otherwise, <c>false</c>.</value>
        bool IsBaseType { get; }

        /// <summary>
        /// Gets the base type of this object type.
        /// </summary>
        /// <value>The type of the base.</value>
        ICmisObjectType BaseType { get; }

        /// <summary>
        /// Gets the parent type of this object type.
        /// </summary>
        /// <value>The type of the parent.</value>
        ICmisObjectType ParentType { get; }

        /// <summary>
        /// Returns a list of child object types that are directly derived from this type.
        /// </summary>
        /// <returns>The list of child object types.</returns>
        IEnumerable<ICmisObjectType> GetChildren();

		/// <summary>
		/// Returns a list of child object types that are directly or indirectly derived from this type.
		/// </summary>
		/// <returns>The list of child object types contained in INode objects.</returns>
        /// <param name="depth">The inheritance depth level. Value must be greater than 0 (zero) or -1 which indicates infinite depth.</param>
		IList<INode<ICmisObjectType>> GetDescendants(int depth);
    }
}
