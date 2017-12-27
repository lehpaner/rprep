using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RufaPoint.Core.Domain.Orders;

namespace RufaPoint.Data.Mapping.Orders
{
    /// <summary>
    /// Mapping class
    /// </summary>
    public partial class ReturnRequestMap : NopEntityTypeConfiguration<ReturnRequest>
    {
        /// <summary>
        /// Ctor
        /// </summary>
        public ReturnRequestMap()
        {
            //this.ToTable("ReturnRequest");
            //this.HasKey(rr => rr.Id);
            //this.Property(rr => rr.ReasonForReturn).IsRequired();
            //this.Property(rr => rr.RequestedAction).IsRequired();

            //this.Ignore(rr => rr.ReturnRequestStatus);

            //this.HasRequired(rr => rr.Customer)
            //    .WithMany(c => c.ReturnRequests)
            //    .HasForeignKey(rr => rr.CustomerId);
        }
        protected override void DoConfig(EntityTypeBuilder<ReturnRequest> builder)
        {
            builder.ToTable("ReturnRequest").HasKey(rr => rr.Id);
            builder.Property(rr => rr.ReasonForReturn).IsRequired();
            builder.Property(rr => rr.RequestedAction).IsRequired();

            builder.Ignore(rr => rr.ReturnRequestStatus);

            builder.HasOne(rr => rr.Customer)
                .WithMany(c => c.ReturnRequests)
                .HasForeignKey(rr => rr.CustomerId);
        }
    }
}