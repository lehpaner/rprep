using RufaPoint.Tests;
using Xunit;

namespace RufaPoint.Data.Tests.Orders
{

    public class CheckoutAttributeValuePersistenceTests : PersistenceTest
    {
        [Fact]
        public void Can_save_and_load_checkoutAttributeValue()
        {
            var cav = this.GetTestCheckoutAttributeValue();
            cav.CheckoutAttribute = this.GetTestCheckoutAttribute();

            var fromDb = SaveAndLoadEntity(cav);
            fromDb.ShouldNotBeNull();
            fromDb.PropertiesShouldEqual(this.GetTestCheckoutAttributeValue());

            fromDb.CheckoutAttribute.ShouldNotBeNull();
            fromDb.CheckoutAttribute.PropertiesShouldEqual(this.GetTestCheckoutAttribute());
        }
    }
}