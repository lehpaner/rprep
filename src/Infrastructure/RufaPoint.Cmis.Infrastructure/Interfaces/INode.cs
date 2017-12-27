using System.Collections.Generic;
namespace RufaPoint.Cmis.Infrastructure.Interfaces
{
	/// <summary>
	/// Node object, can be used for hierarchical definitions.
	/// </summary>
	public interface INode<T>
    {
        /// <summary>
        /// Gets the value of the node.
        /// </summary>
        /// <value>The node value.</value>
        T Value { get; }

        /// <summary>
        /// Gets the display name of the node.
        /// </summary>
        /// <value>The display name.</value>
        string DisplayName { get; }

        /// <summary>
        /// Gets the path of the node.
        /// </summary>
        /// <value>The path.</value>
        string Path { get; }

        /// <summary>
        /// Gets the children of this node.
        /// </summary>
        /// <value>The list of child nodes of this node.</value>
        IList<INode<T>> Children { get; }
    }
}
