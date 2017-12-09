using Autofac;
using Autofac.Core;
using RufaPoint.Core.Configuration;
using RufaPoint.Core.Data;
using RufaPoint.Core.Infrastructure;
using RufaPoint.Core.Infrastructure.DependencyManagement;
using RufaPoint.Data;
using RufaPoint.Plugin.Pickup.PickupInStore.Data;
using RufaPoint.Plugin.Pickup.PickupInStore.Domain;
using RufaPoint.Plugin.Pickup.PickupInStore.Services;
using RufaPoint.Web.Framework.Infrastructure;

namespace RufaPoint.Plugin.Pickup.PickupInStore.Infrastructure
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
            builder.RegisterType<StorePickupPointService>().As<IStorePickupPointService>().InstancePerLifetimeScope();

            //data context
            this.RegisterPluginDataContext<StorePickupPointObjectContext>(builder, "nop_object_context_pickup_in_store-pickup");

            //override required repository with our custom context
            builder.RegisterType<EfRepository<StorePickupPoint>>()
                .As<IRepository<StorePickupPoint>>()
                .WithParameter(ResolvedParameter.ForNamed<IDbContext>("nop_object_context_pickup_in_store-pickup"))
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