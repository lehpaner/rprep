using RufaPoint.Tests;
using Xunit;

namespace RufaPoint.Data.Tests.Directory
{

    public class StateProvincePersistenceTests : PersistenceTest
    {
        [Fact]
        public void Can_save_and_load_stateProvince()
        {
            var stateProvince = this.GetTestStateProvince();
            stateProvince.Country = this.GetTestCountry();

            var fromDb = SaveAndLoadEntity(stateProvince);
            fromDb.ShouldNotBeNull();
            fromDb.PropertiesShouldEqual(this.GetTestStateProvince());

            fromDb.Country.ShouldNotBeNull();
            fromDb.Country.PropertiesShouldEqual(this.GetTestCountry());
        }
    }
}
