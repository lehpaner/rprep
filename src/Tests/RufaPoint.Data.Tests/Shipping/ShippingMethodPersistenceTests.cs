using System.Linq;
using RufaPoint.Tests;
using Xunit;

namespace RufaPoint.Data.Tests.Shipping
{

    public class ShippingMethodPersistenceTests : PersistenceTest
    {
        [Fact]
        public void Can_save_and_load_shippingMethod()
        {
            var shippingMethod = this.GetTestShippingMethod();

            var fromDb = SaveAndLoadEntity(this.GetTestShippingMethod());
            fromDb.ShouldNotBeNull();
            fromDb.PropertiesShouldEqual(shippingMethod);
        }

        [Fact]
        public void Can_save_and_load_shippingMethod_with_restriction()
        {
            var shippingMethod = this.GetTestShippingMethod();
            shippingMethod.RestrictedCountries.Add(this.GetTestCountry());

            var fromDb = SaveAndLoadEntity(shippingMethod);
            fromDb.ShouldNotBeNull();
            fromDb.PropertiesShouldEqual(this.GetTestShippingMethod());

            fromDb.RestrictedCountries.ShouldNotBeNull();
            (fromDb.RestrictedCountries.Count == 1).ShouldBeTrue();
            fromDb.RestrictedCountries.First().PropertiesShouldEqual(this.GetTestCountry());
        }
    }
}