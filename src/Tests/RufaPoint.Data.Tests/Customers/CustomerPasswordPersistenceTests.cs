using RufaPoint.Tests;
using Xunit;

namespace RufaPoint.Data.Tests.Customers
{

    public class CustomerPasswordPersistenceTests : PersistenceTest
    {
        [Fact]
        public void Can_save_and_load_customerPassword()
        {
            var customerPassword = this.GetTestCustomerPassword();
            customerPassword.Customer = this.GetTestCustomer();

            var fromDb = SaveAndLoadEntity(customerPassword);
            fromDb.ShouldNotBeNull();
            fromDb.PropertiesShouldEqual(this.GetTestCustomerPassword());
        }
    }
}