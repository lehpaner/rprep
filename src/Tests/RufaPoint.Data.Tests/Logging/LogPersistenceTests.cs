using RufaPoint.Tests;
using Xunit;

namespace RufaPoint.Data.Tests.Logging
{

    public class LogPersistenceTests : PersistenceTest
    {
        [Fact]
        public void Can_save_and_load_log()
        {
            var log = this.GetTestLog();

            var fromDb = SaveAndLoadEntity(this.GetTestLog());
            fromDb.ShouldNotBeNull();
            fromDb.PropertiesShouldEqual(log);
        }

        [Fact]
        public void Can_save_and_load_log_with_customer()
        {
            var log = this.GetTestLog();
            log.Customer = this.GetTestCustomer();

            var fromDb = SaveAndLoadEntity(log);
            fromDb.ShouldNotBeNull();
            fromDb.PropertiesShouldEqual(this.GetTestLog());
            
            fromDb.Customer.ShouldNotBeNull();
            fromDb.Customer.PropertiesShouldEqual(this.GetTestCustomer());
        }
    }
}
