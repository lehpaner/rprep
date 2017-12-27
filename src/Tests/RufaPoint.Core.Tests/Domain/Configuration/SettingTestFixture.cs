using RufaPoint.Core.Domain.Configuration;
using RufaPoint.Tests;
using Xunit;

namespace RufaPoint.Core.Tests.Domain.Configuration
{
    public class SettingTestFixture
    {
        [Fact]
        public void Can_create_setting()
        {
            var setting = new Setting("Setting1", "Value1");
            setting.Name.ShouldEqual("Setting1");
            setting.Value.ShouldEqual("Value1");
        }
    }
}
