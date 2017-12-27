using System.Linq;
using RufaPoint.Tests;
using Xunit;

namespace RufaPoint.Data.Tests.Localization
{

    public class LanguagePersistenceTests : PersistenceTest
    {
        [Fact]
        public void Can_save_and_load_language()
        {
            var lang = this.GetTestLanguage();

            var fromDb = SaveAndLoadEntity(this.GetTestLanguage());
            fromDb.ShouldNotBeNull();
            fromDb.PropertiesShouldEqual(lang);
        }
    }
}
