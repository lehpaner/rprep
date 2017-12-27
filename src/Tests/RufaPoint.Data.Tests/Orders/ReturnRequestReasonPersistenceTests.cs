using RufaPoint.Tests;
using Xunit;

namespace RufaPoint.Data.Tests.Orders
{

    public class ReturnRequestReasonPersistenceTests : PersistenceTest
    {
        [Fact]
        public void Can_save_and_load_returnRequestReason()
        {
            var returnRequestReason = this.GetTestReturnRequestReason();

            var fromDb = SaveAndLoadEntity(this.GetTestReturnRequestReason());
            fromDb.ShouldNotBeNull();
            fromDb.PropertiesShouldEqual(returnRequestReason);
        }
    }
}
