using RufaPoint.Tests;
using Xunit;

namespace RufaPoint.Data.Tests.Localization
{

    public class LocaleStringResourcePersistenceTests : PersistenceTest
    {
        [Fact]
        public void Can_save_and_load_lst()
        {
            var lst = this.GetTestLocaleStringResource();

            lst.Language = this.GetTestLanguage();

            var fromDb = SaveAndLoadEntity(lst);
            fromDb.ShouldNotBeNull();
            fromDb.PropertiesShouldEqual(this.GetTestLocaleStringResource());

            fromDb.Language.ShouldNotBeNull();
            fromDb.Language.PropertiesShouldEqual(this.GetTestLanguage());
        }
    }
}
