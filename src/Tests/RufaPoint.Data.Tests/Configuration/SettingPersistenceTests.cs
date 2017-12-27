using RufaPoint.Tests;
using Xunit;

namespace RufaPoint.Data.Tests.Configuration
{
    public class SettingPersistenceTests : PersistenceTest
    {
        [Fact]
        public void Can_save_and_load_setting()
        {
            var setting = this.GetTestSetting();

            var fromDb = SaveAndLoadEntity(this.GetTestSetting());
            fromDb.ShouldNotBeNull();
            fromDb.PropertiesShouldEqual(setting);
        }
    }
}
