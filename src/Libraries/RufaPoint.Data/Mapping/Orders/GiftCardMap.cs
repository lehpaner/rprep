using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RufaPoint.Core.Domain.Orders;

namespace RufaPoint.Data.Mapping.Orders
{
    /// <summary>
    /// Mapping class
    /// </summary>
    public partial class GiftCardMap : NopEntityTypeConfiguration<GiftCard>
    {
        /// <summary>
        /// Ctor
        /// </summary>
        public GiftCardMap()
        {
            //this.ToTable("GiftCard");
            //this.HasKey(gc => gc.Id);

            //this.Property(gc => gc.Amount).HasPrecision(18, 4);

            //this.Ignore(gc => gc.GiftCardType);

            //this.HasOptional(gc => gc.PurchasedWithOrderItem)
            //    .WithMany(orderItem => orderItem.AssociatedGiftCards)
            //    .HasForeignKey(gc => gc.PurchasedWithOrderItemId);
        }
        protected override void DoConfig(EntityTypeBuilder<GiftCard> builder)
        {
            builder.ToTable("GiftCard").HasKey(gc => gc.Id);

            //builder.Property(gc => gc.Amount).HasPrecision(18, 4);

            builder.Ignore(gc => gc.GiftCardType);

            builder.HasOne(gc => gc.PurchasedWithOrderItem)
                .WithMany(orderItem => orderItem.AssociatedGiftCards)
                .HasForeignKey(gc => gc.PurchasedWithOrderItemId);
        }
    }
}