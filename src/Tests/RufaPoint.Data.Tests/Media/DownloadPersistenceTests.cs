using RufaPoint.Tests;
using Xunit;

namespace RufaPoint.Data.Tests.Media
{

    public class DownloadPersistenceTests : PersistenceTest
    {
        [Fact]
        public void Can_save_and_load_download()
        {
            var download = this.GetTestDownload();

            var fromDb = SaveAndLoadEntity(this.GetTestDownload());
            fromDb.ShouldNotBeNull();
            fromDb.PropertiesShouldEqual(download);
        }
    }
}
