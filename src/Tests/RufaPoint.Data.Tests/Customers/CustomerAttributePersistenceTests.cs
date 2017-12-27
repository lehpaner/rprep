using System.Linq;
using RufaPoint.Tests;
using Xunit;

namespace RufaPoint.Data.Tests.Customers
{
    public class CustomerAttributePersistenceTests : PersistenceTest
    {
        [Fact]
        public void Can_save_and_load_customerAttribute()
        {
            var ca = this.GetTestCustomerAttribute();

            var fromDb = SaveAndLoadEntity(this.GetTestCustomerAttribute());
            fromDb.ShouldNotBeNull();
            fromDb.PropertiesShouldEqual(ca);
        }

        [Fact]
        public void Can_save_and_load_customerAttribute_with_values()
        {
            var ca = this.GetTestCustomerAttribute();
            ca.CustomerAttributeValues.Add(this.GetTestCustomerAttributeValue());
            var fromDb = SaveAndLoadEntity(ca);
            fromDb.PropertiesShouldEqual(this.GetTestCustomerAttribute());

            fromDb.CustomerAttributeValues.ShouldNotBeNull();
            (fromDb.CustomerAttributeValues.Count == 1).ShouldBeTrue();
            fromDb.CustomerAttributeValues.First().PropertiesShouldEqual(this.GetTestCustomerAttributeValue());
        }
    }
}