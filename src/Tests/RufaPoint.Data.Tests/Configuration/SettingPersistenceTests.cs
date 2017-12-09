using RufaPoint.Tests;
using NUnit.Framework;

namespace RufaPoint.Data.Tests.Configuration
{
    [TestFixture]
    public class SettingPersistenceTests : PersistenceTest
    {
        [Test]
        public void Can_save_and_load_setting()
        {
            var setting = this.GetTestSetting();

            var fromDb = SaveAndLoadEntity(this.GetTestSetting());
            fromDb.ShouldNotBeNull();
            fromDb.PropertiesShouldEqual(setting);
        }
    }
}
