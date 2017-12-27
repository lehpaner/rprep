using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RufaPoint.Core.Domain.Customers;

namespace RufaPoint.Data.Mapping.Customers
{
    /// <summary>
    /// Mapping class
    /// </summary>
    public partial class RewardPointsHistoryMap : NopEntityTypeConfiguration<RewardPointsHistory>
    {
        /// <summary>
        /// Ctor
        /// </summary>
        public RewardPointsHistoryMap()
        {
            //this.ToTable("RewardPointsHistory");
            //this.HasKey(rph => rph.Id);

            //this.Property(rph => rph.UsedAmount).HasPrecision(18, 4);

            //this.HasRequired(rph => rph.Customer)
            //    .WithMany()
            //    .HasForeignKey(rph => rph.CustomerId);

            //this.HasOptional(rph => rph.UsedWithOrder)
            //    .WithOptionalDependent(o => o.RedeemedRewardPointsEntry)
            //    .WillCascadeOnDelete(false);
        }
        protected override void DoConfig(EntityTypeBuilder<RewardPointsHistory> builder)
        {
            builder.ToTable("RewardPointsHistory").HasKey(rph => rph.Id);

            //builder.Property(rph => rph.UsedAmount).HasPrecision(18, 4);

            builder.HasOne(rph => rph.Customer)
                .WithMany()
                .HasForeignKey(rph => rph.CustomerId);

            //this.HasOptional(rph => rph.UsedWithOrder)
            //    .WithOptionalDependent(o => o.RedeemedRewardPointsEntry)
            //    .WillCascadeOnDelete(false);
        }
    }
}