
using System;
namespace RufaPoint.Cmis.Infrastructure.Enums
{
    /// <summary>
    /// CMIS decimal precision.
    /// </summary>
    public enum CmisDecimalPrecision
    {
		/// <summary>
		/// 32-bit precision ("single" as speciﬁed in IEEE-754-1985).
		/// </summary>
        [CmisName(Constants.CmisDecimalPrecisionBits32)]
		Bits32,
		/// <summary>
		/// 64-bit precision ("double" as speciﬁed in IEEE-754-1985).
		/// </summary>
        [CmisName(Constants.CmisDecimalPrecisionBits64)]
		Bits64
    }
}
