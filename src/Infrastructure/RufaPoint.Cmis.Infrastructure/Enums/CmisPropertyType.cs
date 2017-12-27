

namespace RufaPoint.Cmis.Infrastructure.Enums
{
	/// <summary>
	/// CMIS property type.
	/// </summary>
	public enum CmisPropertyType
    {
        /// <summary>
        /// String property type.
        /// </summary>
        [CmisName(Constants.CmisPropertyTypeString)]
        String,

        /// <summary>
        /// Boolean property type. 
        /// </summary>
        [CmisName(Constants.CmisPropertyTypeBoolean)]
        Boolean,

        /// <summary>
        /// Decimal property type.
        /// </summary>
        [CmisName(Constants.CmisPropertyTypeDecimal)]
        Decimal,

        /// <summary>
        /// Integer property type.
        /// </summary>
        [CmisName(Constants.CmisPropertyTypeInteger)]
        Integer,
        
        /// <summary>
        /// The date time.
        /// </summary>
        [CmisName(Constants.CmisPropertyTypeDateTime)]
        DateTime,

        /// <summary>
        /// Uniform Resource Identifier (URI) property type.
        /// </summary>
        [CmisName(Constants.CmisPropertyTypeUri)]
        Uri,

        /// <summary>
        /// Identifier property type. 
        /// </summary>
        [CmisName(Constants.CmisPropertyTypeId)]
        Id,

        /// <summary>
        /// HTML fragment property type.
        /// </summary>
        [CmisName(Constants.CmisPropertyTypeHtml)]
        Html
    }
}
