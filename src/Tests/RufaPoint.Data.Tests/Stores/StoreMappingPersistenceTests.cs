using RufaPoint.Tests;
using Xunit;

namespace RufaPoint.Data.Tests.Stores
{

    public class StoreMappingPersistenceTests : PersistenceTest
    {
        [Fact]
        public void Can_save_and_load_storeMapping()
        {
            var storeMapping = this.GetTestStoreMapping();
            storeMapping.Store = this.GetTestStore();

            var fromDb = SaveAndLoadEntity(storeMapping);
            fromDb.ShouldNotBeNull();
            fromDb.PropertiesShouldEqual(this.GetTestStoreMapping());

            fromDb.Store.ShouldNotBeNull();
            fromDb.Store.PropertiesShouldEqual(this.GetTestStore());
        }
    }
}
