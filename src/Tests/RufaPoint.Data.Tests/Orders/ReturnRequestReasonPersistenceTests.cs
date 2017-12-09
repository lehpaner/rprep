using RufaPoint.Tests;
using NUnit.Framework;

namespace RufaPoint.Data.Tests.Orders
{
    [TestFixture]
    public class ReturnRequestReasonPersistenceTests : PersistenceTest
    {
        [Test]
        public void Can_save_and_load_returnRequestReason()
        {
            var returnRequestReason = this.GetTestReturnRequestReason();

            var fromDb = SaveAndLoadEntity(this.GetTestReturnRequestReason());
            fromDb.ShouldNotBeNull();
            fromDb.PropertiesShouldEqual(returnRequestReason);
        }
    }
}
