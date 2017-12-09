﻿using RufaPoint.Core.Domain.Shipping;

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
            this.ToTable("ShippingMethod");
            this.HasKey(sm => sm.Id);
            this.Property(sm => sm.Name).IsRequired().HasMaxLength(400);

            this.HasMany(sm => sm.RestrictedCountries)
                .WithMany(c => c.RestrictedShippingMethods)
                .Map(m => m.ToTable("ShippingMethodRestrictions"));
        }
    }
}
