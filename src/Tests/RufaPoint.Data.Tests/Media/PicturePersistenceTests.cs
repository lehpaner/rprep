using RufaPoint.Tests;
using Xunit;

namespace RufaPoint.Data.Tests.Media
{

    public class PicturePersistenceTests : PersistenceTest
    {
        [Fact]
        public void Can_save_and_load_picture()
        {
            var picture = this.GetTestPicture();

            var fromDb = SaveAndLoadEntity(this.GetTestPicture());
            fromDb.ShouldNotBeNull();
            fromDb.PropertiesShouldEqual(picture);
        }
    }
}
