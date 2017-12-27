using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RufaPoint.Core.Domain.Shipping;

namespace RufaPoint.Data.Mapping.Shipping
{
    /// <summary>
    /// Mapping class
    /// </summary>
    public class DeliveryDateMap : NopEntityTypeConfiguration<DeliveryDate>
    {
        /// <summary>
        /// Ctor
        /// </summary>
        public DeliveryDateMap()
        {
            //this.ToTable("DeliveryDate");
            //this.HasKey(dd => dd.Id);
            //this.Property(dd => dd.Name).IsRequired().HasMaxLength(400);
        }
        protected override void DoConfig(EntityTypeBuilder<DeliveryDate> builder)
        {
            builder.ToTable("DeliveryDate").HasKey(dd => dd.Id);
            builder.Property(dd => dd.Name).IsRequired().HasMaxLength(400);
        }
    }
}
