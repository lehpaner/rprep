using Autofac;
using Autofac.Core;
using RufaPoint.Core.Caching;
using RufaPoint.Core.Configuration;
using RufaPoint.Core.Data;
using RufaPoint.Core.Infrastructure;
using RufaPoint.Core.Infrastructure.DependencyManagement;
using RufaPoint.Data;
using RufaPoint.Plugin.Tax.FixedOrByCountryStateZip.Data;
using RufaPoint.Plugin.Tax.FixedOrByCountryStateZip.Domain;
using RufaPoint.Plugin.Tax.FixedOrByCountryStateZip.Services;
using RufaPoint.Services.Tax;
using RufaPoint.Web.Framework.Infrastructure;

namespace RufaPoint.Plugin.Tax.FixedOrByCountryStateZip.Infrastructure
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
            //we cache presentation models between requests
            builder.RegisterType<FixedOrByCountryStateZipTaxProvider>().As<ITaxProvider>().InstancePerLifetimeScope();

            builder.RegisterType<CountryStateZipService>().As<ICountryStateZipService>().InstancePerLifetimeScope();

            //data context
            this.RegisterPluginDataContext<CountryStateZipObjectContext>(builder, "nop_object_context_tax_country_state_zip");

            //override required repository with our custom context
            builder.RegisterType<EfRepository<TaxRate>>()
                .As<IRepository<TaxRate>>()
                .WithParameter(ResolvedParameter.ForNamed<IDbContext>("nop_object_context_tax_country_state_zip"))
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