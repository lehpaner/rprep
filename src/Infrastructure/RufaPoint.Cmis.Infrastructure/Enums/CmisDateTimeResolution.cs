

namespace RufaPoint.Cmis.Infrastructure.Enums
{
    /// <summary>
    /// CMIS date time resolution.
    /// </summary>
    public enum CmisDateTimeResolution
    {
		/// <summary>
		/// Year resolution is persisted. Date and time portion of the value should be ignored.
		/// </summary>
        [CmisName(Constants.CmisDateTimeResolutionYear)]
		Year,
		/// <summary>
		/// Date resolution is persisted. Time portion of the value should be ignored.
		/// </summary>
        [CmisName(Constants.CmisDateTimeResolutionDate)]
		Date,
		/// <summary>
		/// Time resolution is persisted.
		/// </summary>
        [CmisName(Constants.CmisDateTimeResolutionTime)]
		Time
    }
}
