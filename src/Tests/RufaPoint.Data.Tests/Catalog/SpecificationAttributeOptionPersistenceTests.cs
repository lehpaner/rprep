using RufaPoint.Tests;
using Xunit;

namespace RufaPoint.Data.Tests.Catalog
{

    public class SpecificationAttributeOptionPersistenceTests : PersistenceTest
    {
        [Fact]
        public void Can_save_and_load_specificationAttributeOption()
        {
            var specificationAttributeOption = this.GetTestSpecificationAttributeOption();
            specificationAttributeOption.SpecificationAttribute = this.GetTestSpecificationAttribute();

            var fromDb = SaveAndLoadEntity(specificationAttributeOption);
            fromDb.ShouldNotBeNull();
            fromDb.PropertiesShouldEqual(this.GetTestSpecificationAttributeOption());

            fromDb.SpecificationAttribute.ShouldNotBeNull();
            fromDb.SpecificationAttribute.PropertiesShouldEqual(this.GetTestSpecificationAttribute());
        }
    }
}
