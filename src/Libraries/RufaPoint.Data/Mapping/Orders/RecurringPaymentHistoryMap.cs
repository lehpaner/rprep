using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RufaPoint.Core.Domain.Orders;

namespace RufaPoint.Data.Mapping.Orders
{
    /// <summary>
    /// Mapping class
    /// </summary>
    public partial class RecurringPaymentHistoryMap : NopEntityTypeConfiguration<RecurringPaymentHistory>
    {
        /// <summary>
        /// Ctor
        /// </summary>
        public RecurringPaymentHistoryMap()
        {
            //this.ToTable("RecurringPaymentHistory");
            //this.HasKey(rph => rph.Id);

            //this.HasRequired(rph => rph.RecurringPayment)
            //    .WithMany(rp => rp.RecurringPaymentHistory)
            //    .HasForeignKey(rph => rph.RecurringPaymentId);

            //entity framework issue if we have navigation property to 'Order'
            //1. save recurring payment with an order
            //2. save recurring payment history with an order
            //3. update associated order => exception is thrown
        }
        protected override void DoConfig(EntityTypeBuilder<RecurringPaymentHistory> builder)
        {
            builder.ToTable("RecurringPaymentHistory").HasKey(rph => rph.Id);

            builder.HasOne(rph => rph.RecurringPayment)
                .WithMany(rp => rp.RecurringPaymentHistory)
                .HasForeignKey(rph => rph.RecurringPaymentId);
        }
    }
}