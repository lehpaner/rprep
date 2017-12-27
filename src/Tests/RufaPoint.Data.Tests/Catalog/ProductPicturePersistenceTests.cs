using RufaPoint.Tests;
using Xunit;

namespace RufaPoint.Data.Tests.Catalog
{

    public class ProductPicturePersistenceTests : PersistenceTest
    {
        [Fact]
        public void Can_save_and_load_productPicture()
        {
            var productPicture = this.GetTestProductPicture();
            productPicture.Product = this.GetTestProduct();
            var fromDb = SaveAndLoadEntity(productPicture);
            fromDb.ShouldNotBeNull();
            fromDb.PropertiesShouldEqual(this.GetTestProductPicture());

            fromDb.Product.ShouldNotBeNull();
            fromDb.Product.PropertiesShouldEqual(this.GetTestProduct());

            fromDb.Picture.ShouldNotBeNull();
            fromDb.Picture.PropertiesShouldEqual(this.GetTestPicture());
        }
    }    
}
