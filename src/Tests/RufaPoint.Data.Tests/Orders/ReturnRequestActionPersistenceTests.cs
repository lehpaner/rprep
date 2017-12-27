using RufaPoint.Tests;
using Xunit;

namespace RufaPoint.Data.Tests.Orders
{

    public class ReturnRequestActionPersistenceTests : PersistenceTest
    {
        [Fact]
        public void Can_save_and_load_returnRequestAction()
        {
            var returnRequestAction = this.GetTestReturnRequestAction();

            var fromDb = SaveAndLoadEntity(this.GetTestReturnRequestAction());
            fromDb.ShouldNotBeNull();
            fromDb.PropertiesShouldEqual(returnRequestAction);
        }
    }
}
