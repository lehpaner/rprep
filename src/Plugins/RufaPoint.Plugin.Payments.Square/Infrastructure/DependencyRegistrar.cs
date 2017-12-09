using Autofac;
using RufaPoint.Core.Configuration;
using RufaPoint.Core.Infrastructure;
using RufaPoint.Core.Infrastructure.DependencyManagement;
using RufaPoint.Plugin.Payments.Square.Services;

namespace RufaPoint.Plugin.Payments.Square.Infrastructure
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
            //register SquarePaymentManager
            builder.RegisterType<SquarePaymentManager>().AsSelf().InstancePerLifetimeScope();
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