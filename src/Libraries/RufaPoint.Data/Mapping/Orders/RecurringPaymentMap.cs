using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RufaPoint.Core.Domain.Orders;

namespace RufaPoint.Data.Mapping.Orders
{
    /// <summary>
    /// Mapping class
    /// </summary>
    public partial class RecurringPaymentMap : NopEntityTypeConfiguration<RecurringPayment>
    {
        /// <summary>
        /// Ctor
        /// </summary>
        public RecurringPaymentMap()
        {
            //this.ToTable("RecurringPayment");
            //this.HasKey(rp => rp.Id);

            //this.Ignore(rp => rp.NextPaymentDate);
            //this.Ignore(rp => rp.CyclesRemaining);
            //this.Ignore(rp => rp.CyclePeriod);

            ////this.HasRequired(rp => rp.InitialOrder).WithOptional().Map(x => x.MapKey("InitialOrderId")).WillCascadeOnDelete(false);
            //this.HasRequired(rp => rp.InitialOrder)
            //    .WithMany()
            //    .HasForeignKey(o => o.InitialOrderId)
            //    .WillCascadeOnDelete(false);
        }
        protected override void DoConfig(EntityTypeBuilder<RecurringPayment> builder)
        {
            builder.ToTable("RecurringPayment").HasKey(rp => rp.Id);

            builder.Ignore(rp => rp.NextPaymentDate);
            builder.Ignore(rp => rp.CyclesRemaining);
            builder.Ignore(rp => rp.CyclePeriod);

            //this.HasRequired(rp => rp.InitialOrder).WithOptional().Map(x => x.MapKey("InitialOrderId")).WillCascadeOnDelete(false);
            builder.HasOne(rp => rp.InitialOrder)
                .WithMany()
                .HasForeignKey(o => o.InitialOrderId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}