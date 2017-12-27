using RufaPoint.Tests;
using Xunit;

namespace RufaPoint.Data.Tests.Orders
{

    public class ReturnRequestPersistenceTests : PersistenceTest
    {
        [Fact]
        public void Can_save_and_load_returnRequest()
        {
            var rr = this.GetTestReturnRequest();

            var fromDb = SaveAndLoadEntity(this.GetTestReturnRequest());
            fromDb.ShouldNotBeNull();
            fromDb.PropertiesShouldEqual(rr);
        }
    }
}