using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RufaPoint.Core.Domain.Orders;

namespace RufaPoint.Data.Mapping.Orders
{
    /// <summary>
    /// Mapping class
    /// </summary>
    public partial class ReturnRequestActionMap : NopEntityTypeConfiguration<ReturnRequestAction>
    {
        /// <summary>
        /// Ctor
        /// </summary>
        public ReturnRequestActionMap()
        {
            //this.ToTable("ReturnRequestAction");
            //this.HasKey(rra => rra.Id);
            //this.Property(rra => rra.Name).IsRequired().HasMaxLength(400);
        }
        protected override void DoConfig(EntityTypeBuilder<ReturnRequestAction> builder)
        {
            builder.ToTable("ReturnRequestAction").HasKey(rra => rra.Id);
            builder.Property(rra => rra.Name).IsRequired().HasMaxLength(400);
        }
    }
}