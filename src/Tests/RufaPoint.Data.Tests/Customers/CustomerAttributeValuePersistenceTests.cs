using RufaPoint.Tests;
using Xunit;

namespace RufaPoint.Data.Tests.Customers
{

    public class CheckoutAttributeValuePersistenceTests : PersistenceTest
    {
        [Fact]
        public void Can_save_and_load_customerAttributeValue()
        {
            var cav = this.GetTestCustomerAttributeValue();
            cav.CustomerAttribute = this.GetTestCustomerAttribute();

            var fromDb = SaveAndLoadEntity(cav);
            fromDb.ShouldNotBeNull();
            fromDb.PropertiesShouldEqual(this.GetTestCustomerAttributeValue());

            fromDb.CustomerAttribute.ShouldNotBeNull();
            fromDb.CustomerAttribute.PropertiesShouldEqual(this.GetTestCustomerAttribute());
        }
    }
}