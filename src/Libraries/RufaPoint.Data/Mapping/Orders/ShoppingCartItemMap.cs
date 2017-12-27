using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RufaPoint.Core.Domain.Orders;

namespace RufaPoint.Data.Mapping.Orders
{
    /// <summary>
    /// Mapping class
    /// </summary>
    public partial class ShoppingCartItemMap : NopEntityTypeConfiguration<ShoppingCartItem>
    {
        /// <summary>
        /// Ctor
        /// </summary>
        public ShoppingCartItemMap()
        {
            //this.ToTable("ShoppingCartItem");
            //this.HasKey(sci => sci.Id);

            //this.Property(sci => sci.CustomerEnteredPrice).HasPrecision(18, 4);

            //this.Ignore(sci => sci.ShoppingCartType);

            //this.HasRequired(sci => sci.Customer)
            //    .WithMany(c => c.ShoppingCartItems)
            //    .HasForeignKey(sci => sci.CustomerId);

            //this.HasRequired(sci => sci.Product)
            //    .WithMany()
            //    .HasForeignKey(sci => sci.ProductId);
        }
        protected override void DoConfig(EntityTypeBuilder<ShoppingCartItem> builder)
        {
            builder.ToTable("ShoppingCartItem").HasKey(sci => sci.Id);

            //builder.Property(sci => sci.CustomerEnteredPrice).HasPrecision(18, 4);

            builder.Ignore(sci => sci.ShoppingCartType);

            builder.HasOne(sci => sci.Customer)
                .WithMany(c => c.ShoppingCartItems)
                .HasForeignKey(sci => sci.CustomerId);

            builder.HasOne(sci => sci.Product)
                .WithMany()
                .HasForeignKey(sci => sci.ProductId);
        }
    }
}
