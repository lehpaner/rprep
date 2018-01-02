using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RufaPoint.Core.Domain.Common;
using RufaPoint.Core.Domain.Customers;

namespace RufaPoint.Data.Mapping.Customers
{
    /// <summary>
    /// Mapping class
    /// </summary>
    public partial class CustomerMap : NopEntityTypeConfiguration<Customer>
    {
        /// <summary>
        /// Ctor
        /// </summary>
        public CustomerMap()
        {
            //this.ToTable("Customer");
            //this.HasKey(c => c.Id);
            //this.Property(u => u.Username).HasMaxLength(1000);
            //this.Property(u => u.Email).HasMaxLength(1000);
            //this.Property(u => u.EmailToRevalidate).HasMaxLength(1000);
            //this.Property(u => u.SystemName).HasMaxLength(400);

            //this.HasMany(c => c.CustomerRoles)
            //    .WithMany()
            //    .Map(m => m.ToTable("Customer_CustomerRole_Mapping"));

            //this.HasMany(c => c.Addresses)
            //    .WithMany()
            //    .Map(m => m.ToTable("CustomerAddresses"));
            //this.HasOptional(c => c.BillingAddress);
            //this.HasOptional(c => c.ShippingAddress);
        }
        protected override void DoConfig(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customer").HasKey(c => c.Id);
            builder.Property(u => u.Username).HasMaxLength(1000);
            builder.Property(u => u.Email).HasMaxLength(1000);
            builder.Property(u => u.EmailToRevalidate).HasMaxLength(1000);
            builder.Property(u => u.SystemName).HasMaxLength(400);
            builder.HasMany(c => c.CustomerRoles);
            builder.HasMany(c => c.Addresses);

            //builder.HasMany(c => c.CustomerRoles)
            //    .WithMany()
            //    .Map(m => m.ToTable("Customer_CustomerRole_Mapping"));

            //builder.HasMany(c => c.Addresses)
            //    .WithMany()
            //    .Map(m => m.ToTable("CustomerAddresses"));
            //builder.HasOptional(c => c.BillingAddress);
            //builder.HasOptional(c => c.ShippingAddress);
        }
    }
}