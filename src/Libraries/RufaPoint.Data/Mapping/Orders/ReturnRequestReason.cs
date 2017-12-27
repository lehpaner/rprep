using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RufaPoint.Core.Domain.Orders;

namespace RufaPoint.Data.Mapping.Orders
{
    /// <summary>
    /// Mapping class
    /// </summary>
    public partial class ReturnRequestReasonMap : NopEntityTypeConfiguration<ReturnRequestReason>
    {
        /// <summary>
        /// Ctor
        /// </summary>
        public ReturnRequestReasonMap()
        {
            //this.ToTable("ReturnRequestReason");
            //this.HasKey(rrr => rrr.Id);
            //this.Property(rrr => rrr.Name).IsRequired().HasMaxLength(400);
        }
        protected override void DoConfig(EntityTypeBuilder<ReturnRequestReason> builder)
        {
            builder.ToTable("ReturnRequestReason").HasKey(rrr => rrr.Id);
            builder.Property(rrr => rrr.Name).IsRequired().HasMaxLength(400);
        }
    }
}