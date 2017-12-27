using RufaPoint.Tests;
using Xunit;

namespace RufaPoint.Data.Tests.Stores
{

    public class StorePersistenceTests : PersistenceTest
    {
        [Fact]
        public void Can_save_and_load_store()
        {
            var store = this.GetTestStore();

            var fromDb = SaveAndLoadEntity(this.GetTestStore());
            fromDb.ShouldNotBeNull();
            fromDb.PropertiesShouldEqual(store);
        }
    }
}
