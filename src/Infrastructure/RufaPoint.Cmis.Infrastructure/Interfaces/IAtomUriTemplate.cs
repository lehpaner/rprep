

using RufaPoint.Cmis.Infrastructure.Enums;

namespace RufaPoint.Cmis.Infrastructure.Interfaces
{
	/// <summary>
	/// Atom URI template.
	/// </summary>
	public interface IAtomUriTemplate
    {
		/// <summary>
		/// Gets or sets the template.
		/// </summary>
		/// <value>The template.</value>
		string Template { get; set; }

		/// <summary>
		/// Gets or sets the type of the URI template.
		/// </summary>
		/// <value>The type of the URI template.</value>
		CmisUriTemplateType UriTemplateType { get; set; }

		/// <summary>
		/// Gets or sets the CMIS media type.
		/// </summary>
		/// <value>The CMIS media type.</value>
		CmisMediaType MediaType { get; set; }
    }
}