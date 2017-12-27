using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RufaPoint.Core.Domain.Discounts;

namespace RufaPoint.Data.Mapping.Discounts
{
    /// <summary>
    /// Mapping class
    /// </summary>
    public partial class DiscountUsageHistoryMap : NopEntityTypeConfiguration<DiscountUsageHistory>
    {
        /// <summary>
        /// Ctor
        /// </summary>
        public DiscountUsageHistoryMap()
        {
            //this.ToTable("DiscountUsageHistory");
            //this.HasKey(duh => duh.Id);

            //this.HasRequired(duh => duh.Discount)
            //    .WithMany()
            //    .HasForeignKey(duh => duh.DiscountId);

            //this.HasRequired(duh => duh.Order)
            //    .WithMany(o => o.DiscountUsageHistory)
            //    .HasForeignKey(duh => duh.OrderId);
        }
        protected override void DoConfig(EntityTypeBuilder<DiscountUsageHistory> builder)
        {
            builder.ToTable("DiscountUsageHistory").HasKey(duh => duh.Id);

            builder.HasOne(duh => duh.Discount)
                .WithMany()
                .HasForeignKey(duh => duh.DiscountId);

            builder.HasOne(duh => duh.Order)
                .WithMany(o => o.DiscountUsageHistory)
                .HasForeignKey(duh => duh.OrderId);
        }
    }
}