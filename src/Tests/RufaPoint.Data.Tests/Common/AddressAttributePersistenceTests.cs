using System.Linq;
using RufaPoint.Tests;
using Xunit;

namespace RufaPoint.Data.Tests.Common
{

    public class AddressAttributePersistenceTests : PersistenceTest
    {
        [Fact]
        public void Can_save_and_load_addressAttribute()
        {
            var ca = this.GetTestAddressAttribute();

            var fromDb = SaveAndLoadEntity(this.GetTestAddressAttribute());
            fromDb.ShouldNotBeNull();
            fromDb.PropertiesShouldEqual(ca);
        }

        [Fact]
        public void Can_save_and_load_addressAttribute_with_values()
        {
            var ca = this.GetTestAddressAttribute();
            ca.AddressAttributeValues.Add(this.GetTestAddressAttributeValue());
            var fromDb = SaveAndLoadEntity(ca);
            fromDb.ShouldNotBeNull();
            fromDb.PropertiesShouldEqual(this.GetTestAddressAttribute());
            fromDb.AddressAttributeValues.ShouldNotBeNull();
            (fromDb.AddressAttributeValues.Count == 1).ShouldBeTrue();
            fromDb.AddressAttributeValues.First().PropertiesShouldEqual(this.GetTestAddressAttributeValue());
        }
    }
}