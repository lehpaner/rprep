using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RufaPoint.Core.Domain.Orders;

namespace RufaPoint.Data.Mapping.Orders
{
    /// <summary>
    /// Mapping class
    /// </summary>
    public partial class GiftCardUsageHistoryMap : NopEntityTypeConfiguration<GiftCardUsageHistory>
    {
        /// <summary>
        /// Ctor
        /// </summary>
        public GiftCardUsageHistoryMap()
        {
            //this.ToTable("GiftCardUsageHistory");
            //this.HasKey(gcuh => gcuh.Id);
            //this.Property(gcuh => gcuh.UsedValue).HasPrecision(18, 4);
            ////this.Property(gcuh => gcuh.UsedValueInCustomerCurrency).HasPrecision(18, 4);

            //this.HasRequired(gcuh => gcuh.GiftCard)
            //    .WithMany(gc => gc.GiftCardUsageHistory)
            //    .HasForeignKey(gcuh => gcuh.GiftCardId);

            //this.HasRequired(gcuh => gcuh.UsedWithOrder)
            //    .WithMany(o => o.GiftCardUsageHistory)
            //    .HasForeignKey(gcuh => gcuh.UsedWithOrderId);
        }
        protected override void DoConfig(EntityTypeBuilder<GiftCardUsageHistory> builder)
        {
            builder.ToTable("GiftCardUsageHistory").HasKey(gcuh => gcuh.Id);
            //builder.Property(gcuh => gcuh.UsedValue).HasPrecision(18, 4);
            ////this.Property(gcuh => gcuh.UsedValueInCustomerCurrency).HasPrecision(18, 4);

            builder.HasOne(gcuh => gcuh.GiftCard)
                .WithMany(gc => gc.GiftCardUsageHistory)
                .HasForeignKey(gcuh => gcuh.GiftCardId);

            builder.HasOne(gcuh => gcuh.UsedWithOrder)
                .WithMany(o => o.GiftCardUsageHistory)
                .HasForeignKey(gcuh => gcuh.UsedWithOrderId);
        }
    }
}