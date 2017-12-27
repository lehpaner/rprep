using RufaPoint.Core.Configuration;
using RufaPoint.Services.Configuration;
using RufaPoint.Tests;
using Xunit;

namespace RufaPoint.Services.Tests.Configuration
{
    public class ConfigurationProviderTests : ServiceTest
    {
        ISettingService _settingService;

        public ConfigurationProviderTests()
        {
            _settingService = new ConfigFileSettingService(null, null, null);
        }

        [Fact]
        public void Can_get_settings()
        {
            // requires settings to be set in app.config in format TestSettings.[PropertyName]
            var settings = _settingService.LoadSetting<TestSettings>();
            settings.ServerName.ShouldEqual("Ruby");
            settings.Ip.ShouldEqual("192.168.0.1");
            settings.PortNumber.ShouldEqual(21);
            settings.Username.ShouldEqual("admin");
            settings.Password.ShouldEqual("password");
        }
    }

    public class TestSettings : ISettings
    {
        public string ServerName { get; set; }
        public string Ip { get; set; }
        public int PortNumber { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
