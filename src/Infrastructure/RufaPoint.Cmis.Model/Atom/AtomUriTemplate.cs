
namespace RufaPoint.Cmis.Model.Atom
{
    using Cmis.Infrastructure.Interfaces;
    using RufaPoint.Cmis.Infrastructure.Enums;

    /// <summary>
    /// Atom URI template.
    /// </summary>
    public class AtomUriTemplate : IAtomUriTemplate
    {
        #region Properties

        /// <summary>
        /// Gets or sets the template.
        /// </summary>
        /// <value>The template.</value>
        public string Template { get; set; }

        /// <summary>
        /// Gets or sets the type of the URI template.
        /// </summary>
        /// <value>The type of the URI template.</value>
        public CmisUriTemplateType UriTemplateType { get; set; }

		/// <summary>
		/// Gets or sets the CMIS media type.
		/// </summary>
		/// <value>The CMIS media type.</value>
        public CmisMediaType MediaType { get; set; }

        #endregion
    }
}
