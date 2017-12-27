using RufaPoint.Tests;
using Xunit;

namespace RufaPoint.Data.Tests.Directory
{

    public class MeasureDimensionPersistenceTests : PersistenceTest
    {
        [Fact]
        public void Can_save_and_load_measureDimension()
        {
            var measureDimension = this.GetTestMeasureDimension();

            var fromDb = SaveAndLoadEntity(this.GetTestMeasureDimension());
            fromDb.ShouldNotBeNull();
            fromDb.PropertiesShouldEqual(measureDimension);
        }
    }
}
