using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RufaPoint.Core.Domain.Orders;

namespace RufaPoint.Data.Mapping.Orders
{
    /// <summary>
    /// Mapping class
    /// </summary>
    public partial class OrderItemMap : NopEntityTypeConfiguration<OrderItem>
    {
        /// <summary>
        /// Ctor
        /// </summary>
        public OrderItemMap()
        {
            //this.ToTable("OrderItem");
            //this.HasKey(orderItem => orderItem.Id);

            //this.Property(orderItem => orderItem.UnitPriceInclTax).HasPrecision(18, 4);
            //this.Property(orderItem => orderItem.UnitPriceExclTax).HasPrecision(18, 4);
            //this.Property(orderItem => orderItem.PriceInclTax).HasPrecision(18, 4);
            //this.Property(orderItem => orderItem.PriceExclTax).HasPrecision(18, 4);
            //this.Property(orderItem => orderItem.DiscountAmountInclTax).HasPrecision(18, 4);
            //this.Property(orderItem => orderItem.DiscountAmountExclTax).HasPrecision(18, 4);
            //this.Property(orderItem => orderItem.OriginalProductCost).HasPrecision(18, 4);
            //this.Property(orderItem => orderItem.ItemWeight).HasPrecision(18, 4);


            //this.HasRequired(orderItem => orderItem.Order)
            //    .WithMany(o => o.OrderItems)
            //    .HasForeignKey(orderItem => orderItem.OrderId);

            //this.HasRequired(orderItem => orderItem.Product)
            //    .WithMany()
            //    .HasForeignKey(orderItem => orderItem.ProductId);
        }
        protected override void DoConfig(EntityTypeBuilder<OrderItem> builder)
        {
            builder.ToTable("OrderItem").HasKey(orderItem => orderItem.Id);

            //builder.Property(orderItem => orderItem.UnitPriceInclTax).HasPrecision(18, 4);
            //builder.Property(orderItem => orderItem.UnitPriceExclTax).HasPrecision(18, 4);
            //builder.Property(orderItem => orderItem.PriceInclTax).HasPrecision(18, 4);
            //builder.Property(orderItem => orderItem.PriceExclTax).HasPrecision(18, 4);
            //builder.Property(orderItem => orderItem.DiscountAmountInclTax).HasPrecision(18, 4);
            //builder.Property(orderItem => orderItem.DiscountAmountExclTax).HasPrecision(18, 4);
            //builder.Property(orderItem => orderItem.OriginalProductCost).HasPrecision(18, 4);
            //builder.Property(orderItem => orderItem.ItemWeight).HasPrecision(18, 4);


            builder.HasOne(orderItem => orderItem.Order)
                .WithMany(o => o.OrderItems)
                .HasForeignKey(orderItem => orderItem.OrderId);

            builder.HasOne(orderItem => orderItem.Product)
                .WithMany()
                .HasForeignKey(orderItem => orderItem.ProductId);
        }
    }
}