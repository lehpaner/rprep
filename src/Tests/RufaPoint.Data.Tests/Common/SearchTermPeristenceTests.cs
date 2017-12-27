using RufaPoint.Tests;
using Xunit;

namespace RufaPoint.Data.Tests.Common
{

    public class SearchTermPeristenceTests : PersistenceTest
    {
        [Fact]
        public void Can_save_and_load_searchTerm()
        {
            var searchTerm = this.GetTestSearchTerm();

            var fromDb = SaveAndLoadEntity(this.GetTestSearchTerm());
            fromDb.ShouldNotBeNull();

            fromDb.PropertiesShouldEqual(searchTerm);
        }
    }
}
