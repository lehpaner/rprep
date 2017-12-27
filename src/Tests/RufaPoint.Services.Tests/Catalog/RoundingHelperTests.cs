using RufaPoint.Core.Domain.Directory;
using RufaPoint.Services.Catalog;
using RufaPoint.Tests;
using Xunit;

namespace RufaPoint.Services.Tests.Catalog
{

    public class RoundingHelperTests : ServiceTest
    {
        [Theory]
        [InlineData(12.366, 12.37, RoundingType.Rounding001)]
        [InlineData(12.363, 12.36, RoundingType.Rounding001)]
        [InlineData(12.000, 12.00, RoundingType.Rounding001)]
        [InlineData(12.001, 12.00, RoundingType.Rounding001)]
        [InlineData(12.34, 12.35, RoundingType.Rounding005Up)]
        [InlineData(12.36, 12.40, RoundingType.Rounding005Up)]
        [InlineData(12.35, 12.35, RoundingType.Rounding005Up)]
        [InlineData(12.00, 12.00, RoundingType.Rounding005Up)]
        [InlineData(12.05, 12.05, RoundingType.Rounding005Up)]
        [InlineData(12.20, 12.20, RoundingType.Rounding005Up)]
        [InlineData(12.001, 12.00, RoundingType.Rounding005Up)]
        [InlineData(12.34, 12.30, RoundingType.Rounding005Down)]
        [InlineData(12.36, 12.35, RoundingType.Rounding005Down)]
        [InlineData(12.00, 12.00, RoundingType.Rounding005Down)]
        [InlineData(12.05, 12.05, RoundingType.Rounding005Down)]
        [InlineData(12.20, 12.20, RoundingType.Rounding005Down)]
        [InlineData(12.35, 12.40, RoundingType.Rounding01Up)]
        [InlineData(12.36, 12.40, RoundingType.Rounding01Up)]
        [InlineData(12.00, 12.00, RoundingType.Rounding01Up)]
        [InlineData(12.10, 12.10, RoundingType.Rounding01Up)]
        [InlineData(12.35, 12.30, RoundingType.Rounding01Down)]
        [InlineData(12.36, 12.40, RoundingType.Rounding01Down)]
        [InlineData(12.00, 12.00, RoundingType.Rounding01Down)]
        [InlineData(12.10, 12.10, RoundingType.Rounding01Down)]
        [InlineData(12.24, 12.00, RoundingType.Rounding05)]
        [InlineData(12.49, 12.50, RoundingType.Rounding05)]
        [InlineData(12.74, 12.50, RoundingType.Rounding05)]
        [InlineData(12.99, 13.00, RoundingType.Rounding05)]
        [InlineData(12.00, 12.00, RoundingType.Rounding05)]
        [InlineData(12.50, 12.50, RoundingType.Rounding05)]
        [InlineData(12.49, 12.00, RoundingType.Rounding1)]
        [InlineData(12.50, 13.00, RoundingType.Rounding1)]
        [InlineData(12.00, 12.00, RoundingType.Rounding1)]
        [InlineData(12.01, 13.00, RoundingType.Rounding1Up)]
        [InlineData(12.99, 13.00, RoundingType.Rounding1Up)]
        [InlineData(12.00, 12.00, RoundingType.Rounding1Up)]
        public void can_round(decimal valueToRoundig, decimal roundedValue, RoundingType roundingType)
        {
            valueToRoundig.Round(roundingType).ShouldEqual(roundedValue);
        }
    }
}