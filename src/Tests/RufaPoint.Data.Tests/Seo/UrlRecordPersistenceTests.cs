using RufaPoint.Tests;
using Xunit;

namespace RufaPoint.Data.Tests.Seo
{

    public class UrlRecordPersistenceTests : PersistenceTest
    {
        [Fact]
        public void Can_save_and_load_urlRecord()
        {
            var urlRecord = this.UrlRecord();

            var fromDb = SaveAndLoadEntity(this.UrlRecord());
            fromDb.ShouldNotBeNull();
            fromDb.PropertiesShouldEqual(urlRecord);
        }
    }
}
