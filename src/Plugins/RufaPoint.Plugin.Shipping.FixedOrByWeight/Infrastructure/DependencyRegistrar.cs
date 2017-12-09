using Autofac;
using Autofac.Core;
using RufaPoint.Core.Configuration;
using RufaPoint.Core.Data;
using RufaPoint.Core.Infrastructure;
using RufaPoint.Core.Infrastructure.DependencyManagement;
using RufaPoint.Data;
using RufaPoint.Plugin.Shipping.FixedOrByWeight.Data;
using RufaPoint.Plugin.Shipping.FixedOrByWeight.Domain;
using RufaPoint.Plugin.Shipping.FixedOrByWeight.Services;
using RufaPoint.Web.Framework.Infrastructure;

namespace RufaPoint.Plugin.Shipping.FixedOrByWeight.Infrastructure
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
        public virtual void Register(ContainerBuilder builder, ITypeFinder typeFinder, RufaPointConfig config)
        {
            builder.RegisterType<ShippingByWeightService>().As<IShippingByWeightService>().InstancePerLifetimeScope();

            //data context
            this.RegisterPluginDataContext<ShippingByWeightObjectContext>(builder, "nop_object_context_shipping_weight_zip");

            //override required repository with our custom context
            builder.RegisterType<EfRepository<ShippingByWeightRecord>>()
                .As<IRepository<ShippingByWeightRecord>>()
                .WithParameter(ResolvedParameter.ForNamed<IDbContext>("nop_object_context_shipping_weight_zip"))
                .InstancePerLifetimeScope();
        }

        /// <summary>
        /// Order of this dependency registrar implementation
        /// </summary>
        public int Order
        {
            get { return 1; }
        }
    }
}
