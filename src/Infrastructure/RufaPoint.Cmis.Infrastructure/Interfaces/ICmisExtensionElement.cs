
namespace RufaPoint.Cmis.Infrastructure.Interfaces
{
    using System.Collections.Generic;

	/// <summary>
	/// CMIS extension element. See http://docs.oasis-open.org/cmis/CMIS/v1.1/os/CMIS-v1.1-os.html
	/// </summary>
	public interface ICmisExtensionElement
    {
		/// <summary>
		/// Gets or sets the CMIS extension name.
		/// </summary>
		/// <value>The CMIS extension name.</value>
		string Name { get; set; }

		/// <summary>
		/// Gets or sets the CMIS extension namespace.
		/// </summary>
		/// <value>The CMIS extension namespace.</value>
		string Namespace { get; set; }

		/// <summary>
		/// Gets or sets the CMIS extension value.
		/// </summary>
		/// <value>The CMIS extension value.</value>
		string Value { get; set; }

		/// <summary>
		/// Gets or sets the CMIS extension attributes.
		/// </summary>
		/// <value>The CMIS extension attributes.</value>
		IDictionary<string, string> Attributes { get; set; }

		/// <summary>
		/// Gets or sets optional child CMIS extension elements.
		/// </summary>
		/// <value>The CMIS extension children.</value>
		IList<ICmisExtensionElement> Children { get; set; }
    }
}
