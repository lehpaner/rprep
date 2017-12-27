using RufaPoint.Tests;
using Xunit;

namespace RufaPoint.Data.Tests.Messages
{

    public class EmailAccountPersistenceTests : PersistenceTest
    {
        [Fact]
        public void Can_save_and_load_emailAccount()
        {
            var emailAccount = this.GetTestEmailAccount();

            var fromDb = SaveAndLoadEntity(this.GetTestEmailAccount());
            fromDb.ShouldNotBeNull();
            fromDb.PropertiesShouldEqual(emailAccount);
        }
    }
}
