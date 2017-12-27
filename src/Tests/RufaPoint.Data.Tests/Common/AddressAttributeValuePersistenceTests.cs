using RufaPoint.Tests;
using Xunit;

namespace RufaPoint.Data.Tests.Common
{

    public class CheckoutAttributeValuePersistenceTests : PersistenceTest
    {
        [Fact]
        public void Can_save_and_load_addressAttributeValue()
        {
            var cav = this.GetTestAddressAttributeValue();
            cav.AddressAttribute = this.GetTestAddressAttribute();

            var fromDb = SaveAndLoadEntity(cav);
            fromDb.ShouldNotBeNull();
            fromDb.PropertiesShouldEqual(this.GetTestAddressAttributeValue());

            fromDb.AddressAttribute.ShouldNotBeNull();
            fromDb.AddressAttribute.PropertiesShouldEqual(this.GetTestAddressAttribute());
        }
    }
}