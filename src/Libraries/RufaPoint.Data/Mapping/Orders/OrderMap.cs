using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RufaPoint.Core.Domain.Orders;

namespace RufaPoint.Data.Mapping.Orders
{
    /// <summary>
    /// Mapping class
    /// </summary>
    public partial class OrderMap : NopEntityTypeConfiguration<Order>
    {
        /// <summary>
        /// Ctor
        /// </summary>
        public OrderMap()
        {
            //this.ToTable("Order");
            //this.HasKey(o => o.Id);
            //this.Property(o => o.CurrencyRate).HasPrecision(18, 8);
            //this.Property(o => o.OrderSubtotalInclTax).HasPrecision(18, 4);
            //this.Property(o => o.OrderSubtotalExclTax).HasPrecision(18, 4);
            //this.Property(o => o.OrderSubTotalDiscountInclTax).HasPrecision(18, 4);
            //this.Property(o => o.OrderSubTotalDiscountExclTax).HasPrecision(18, 4);
            //this.Property(o => o.OrderShippingInclTax).HasPrecision(18, 4);
            //this.Property(o => o.OrderShippingExclTax).HasPrecision(18, 4);
            //this.Property(o => o.PaymentMethodAdditionalFeeInclTax).HasPrecision(18, 4);
            //this.Property(o => o.PaymentMethodAdditionalFeeExclTax).HasPrecision(18, 4);
            //this.Property(o => o.OrderTax).HasPrecision(18, 4);
            //this.Property(o => o.OrderDiscount).HasPrecision(18, 4);
            //this.Property(o => o.OrderTotal).HasPrecision(18, 4);
            //this.Property(o => o.RefundedAmount).HasPrecision(18, 4);
            //this.Property(o => o.CustomOrderNumber).IsRequired();

            //this.Ignore(o => o.OrderStatus);
            //this.Ignore(o => o.PaymentStatus);
            //this.Ignore(o => o.ShippingStatus);
            //this.Ignore(o => o.CustomerTaxDisplayType);
            //this.Ignore(o => o.TaxRatesDictionary);

            //this.HasRequired(o => o.Customer)
            //    .WithMany()
            //    .HasForeignKey(o => o.CustomerId);

            ////code below is commented because it causes some issues on big databases - https://www.nopcommerce.com/boards/t/11126/bug-version-20-command-confirm-takes-several-minutes-using-big-databases.aspx
            ////this.HasRequired(o => o.BillingAddress).WithOptional().Map(x => x.MapKey("BillingAddressId")).WillCascadeOnDelete(false);
            ////this.HasOptional(o => o.ShippingAddress).WithOptionalDependent().Map(x => x.MapKey("ShippingAddressId")).WillCascadeOnDelete(false);
            //this.HasRequired(o => o.BillingAddress)
            //    .WithMany()
            //    .HasForeignKey(o => o.BillingAddressId)
            //    .WillCascadeOnDelete(false);
            //this.HasOptional(o => o.ShippingAddress)
            //    .WithMany()
            //    .HasForeignKey(o => o.ShippingAddressId)
            //    .WillCascadeOnDelete(false);
            //this.HasOptional(o => o.PickupAddress)
            //    .WithMany()
            //    .HasForeignKey(o => o.PickupAddressId)
            //    .WillCascadeOnDelete(false);
        }
        protected override void DoConfig(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Order").HasKey(o => o.Id);
            //builder.Property(o => o.CurrencyRate).HasPrecision(18, 8);
            //builder.Property(o => o.OrderSubtotalInclTax).HasPrecision(18, 4);
            //builder.Property(o => o.OrderSubtotalExclTax).HasPrecision(18, 4);
            //builder.Property(o => o.OrderSubTotalDiscountInclTax).HasPrecision(18, 4);
            //builder.Property(o => o.OrderSubTotalDiscountExclTax).HasPrecision(18, 4);
            //builder.Property(o => o.OrderShippingInclTax).HasPrecision(18, 4);
            //builder.Property(o => o.OrderShippingExclTax).HasPrecision(18, 4);
            //builder.Property(o => o.PaymentMethodAdditionalFeeInclTax).HasPrecision(18, 4);
            //builder.Property(o => o.PaymentMethodAdditionalFeeExclTax).HasPrecision(18, 4);
            //builder.Property(o => o.OrderTax).HasPrecision(18, 4);
            //builder.Property(o => o.OrderDiscount).HasPrecision(18, 4);
            //builder.Property(o => o.OrderTotal).HasPrecision(18, 4);
            //builder.Property(o => o.RefundedAmount).HasPrecision(18, 4);
            builder.Property(o => o.CustomOrderNumber).IsRequired();

            builder.Ignore(o => o.OrderStatus);
            builder.Ignore(o => o.PaymentStatus);
            builder.Ignore(o => o.ShippingStatus);
            builder.Ignore(o => o.CustomerTaxDisplayType);
            builder.Ignore(o => o.TaxRatesDictionary);

            builder.HasOne(o => o.Customer)
                .WithMany()
                .HasForeignKey(o => o.CustomerId);

            //code below is commented because it causes some issues on big databases - https://www.nopcommerce.com/boards/t/11126/bug-version-20-command-confirm-takes-several-minutes-using-big-databases.aspx
            //this.HasRequired(o => o.BillingAddress).WithOptional().Map(x => x.MapKey("BillingAddressId")).WillCascadeOnDelete(false);
            //this.HasOptional(o => o.ShippingAddress).WithOptionalDependent().Map(x => x.MapKey("ShippingAddressId")).WillCascadeOnDelete(false);
            builder.HasOne(o => o.BillingAddress)
                .WithMany()
                .HasForeignKey(o => o.BillingAddressId)
                .OnDelete(DeleteBehavior.ClientSetNull);
            builder.HasOne(o => o.ShippingAddress)
                .WithMany()
                .HasForeignKey(o => o.ShippingAddressId)
                .OnDelete(DeleteBehavior.ClientSetNull);
            builder.HasOne(o => o.PickupAddress)
                .WithMany()
                .HasForeignKey(o => o.PickupAddressId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}