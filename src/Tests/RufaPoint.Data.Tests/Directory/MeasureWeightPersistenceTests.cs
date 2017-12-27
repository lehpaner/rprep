using RufaPoint.Tests;
using Xunit;

namespace RufaPoint.Data.Tests.Directory
{

    public class MeasureWeightPersistenceTests : PersistenceTest
    {
        [Fact]
        public void Can_save_and_load_measureWeight()
        {
            var measureWeight = this.GetTestMeasureWeight();

            var fromDb = SaveAndLoadEntity(this.GetTestMeasureWeight());
            fromDb.ShouldNotBeNull();
            fromDb.PropertiesShouldEqual(measureWeight);
        }
    }
}
