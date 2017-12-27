using RufaPoint.Tests;
using Xunit;

namespace RufaPoint.Data.Tests.Customers
{

    public class ExternalAuthenticationRecordPersistenceTests : PersistenceTest
    {
        [Fact]
        public void Can_save_and_load_externalAuthenticationRecord()
        {
            var externalAuthenticationRecord = this.GetTestExternalAuthenticationRecord();
            externalAuthenticationRecord.Customer = this.GetTestCustomer();

            var fromDb = SaveAndLoadEntity(externalAuthenticationRecord);
            fromDb.ShouldNotBeNull();
            fromDb.PropertiesShouldEqual(this.GetTestExternalAuthenticationRecord());

            fromDb.Customer.ShouldNotBeNull();
            fromDb.Customer.PropertiesShouldEqual(this.GetTestCustomer());
        }
    }
}