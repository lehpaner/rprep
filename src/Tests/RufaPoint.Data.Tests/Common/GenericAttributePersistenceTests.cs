using RufaPoint.Tests;
using Xunit;

namespace RufaPoint.Data.Tests.Common
{

    public class GenericAttributePersistenceTests : PersistenceTest
    {
        [Fact]
        public void Can_save_and_load_genericAttribute()
        {
            var genericAttribute = this.GetTestGenericAttribute();

            var fromDb = SaveAndLoadEntity(this.GetTestGenericAttribute());
            fromDb.ShouldNotBeNull();
            fromDb.PropertiesShouldEqual(genericAttribute);
        }
    }
}