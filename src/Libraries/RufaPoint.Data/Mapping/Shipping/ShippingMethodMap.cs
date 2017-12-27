using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RufaPoint.Core.Domain.Shipping;

namespace RufaPoint.Data.Mapping.Shipping
{
    /// <summary>
    /// Mapping class
    /// </summary>
    public class ShippingMethodMap : NopEntityTypeConfiguration<ShippingMethod>
    {
        /// <summary>
        /// Ctor
        /// </summary>
        public ShippingMethodMap()
        {
            //this.ToTable("ShippingMethod");
            //this.HasKey(sm => sm.Id);
            //this.Property(sm => sm.Name).IsRequired().HasMaxLength(400);

            //this.HasMany(sm => sm.RestrictedCountries)
            //    .WithMany(c => c.RestrictedShippingMethods)
            //    .Map(m => m.ToTable("ShippingMethodRestrictions"));
        }
        protected override void DoConfig(EntityTypeBuilder<ShippingMethod> builder)
        {
            builder.ToTable("ShippingMethod").HasKey(sm => sm.Id);
            builder.Property(sm => sm.Name).IsRequired().HasMaxLength(400);

            //builder.HasMany(sm => sm.RestrictedCountries)
            //    .WithMany(c => c.RestrictedShippingMethods)
            //    .Map(m => m.ToTable("ShippingMethodRestrictions"));
        }
    }
}
