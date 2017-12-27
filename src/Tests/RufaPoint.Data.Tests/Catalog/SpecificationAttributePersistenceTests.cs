using System.Linq;
using RufaPoint.Tests;
using Xunit;

namespace RufaPoint.Data.Tests.Catalog
{

    public class SpecificationAttributePersistenceTests : PersistenceTest
    {
        [Fact]
        public void Can_save_and_load_specificationAttribute()
        {
            var specificationAttribute = this.GetTestSpecificationAttribute();

            var fromDb = SaveAndLoadEntity(this.GetTestSpecificationAttribute());
            fromDb.ShouldNotBeNull();
            fromDb.PropertiesShouldEqual(specificationAttribute);
        }

        [Fact]
        public void Can_save_and_load_specificationAttribute_with_specificationAttributeOptions()
        {
            var specificationAttribute = this.GetTestSpecificationAttribute();
            specificationAttribute.SpecificationAttributeOptions.Add(this.GetTestSpecificationAttributeOption());
            var fromDb = SaveAndLoadEntity(specificationAttribute);
            fromDb.ShouldNotBeNull();
            fromDb.PropertiesShouldEqual(this.GetTestSpecificationAttribute());

            fromDb.SpecificationAttributeOptions.ShouldNotBeNull();
            (fromDb.SpecificationAttributeOptions.Count == 1).ShouldBeTrue();
            fromDb.SpecificationAttributeOptions.First().PropertiesShouldEqual(this.GetTestSpecificationAttributeOption());
        }
    }
}
