using Autofac;
using RufaPoint.Core.Caching;
using RufaPoint.Core.Configuration;
using RufaPoint.Core.Infrastructure;
using RufaPoint.Core.Infrastructure.DependencyManagement;

namespace RufaPoint.Services.Tests
{
    /// <summary>
    /// Dependency registrar
    /// </summary>
    public class DependencyRegistrar : IDependencyRegistrar
    {
        /// <summary>
        /// Register services and interfaces
        /// </summary>
        /// <param name="builder">Container builder</param>
        /// <param name="typeFinder">Type finder</param>
        /// <param name="config">Config</param>
        public virtual void Register(ContainerBuilder builder, ITypeFinder typeFinder, CoreAppConfig config)
        {
            //cache managers
            builder.RegisterType<DummyCacheManager>().As<ICacheManager>().Named<ICacheManager>("nop_cache_static").SingleInstance();

        }

        /// <summary>
        /// Order of this dependency registrar implementation
        /// </summary>
        public int Order
        {
            get { return 0; }
        }
    }

}
