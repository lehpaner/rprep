using AutoMapper;
using RufaPoint.Web.Areas.Admin.Infrastructure.Mapper;
using RufaPoint.Core.Infrastructure.Mapper;
using Xunit;

namespace RufaPoint.Web.MVC.Tests.Admin.Infrastructure
{

    public class AutoMapperConfigurationTest
    {
        [Fact]
        public void Configuration_is_valid()
        {
            var config = new MapperConfiguration(cfg => {
                
                    cfg.AddProfile(typeof(AdminMapperConfiguration));
            });
            
            AutoMapperConfiguration.Init(config);
            AutoMapperConfiguration.MapperConfiguration.AssertConfigurationIsValid();
        }
    }
}