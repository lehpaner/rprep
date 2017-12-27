using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RufaPoint.Core.Domain.Shipping;

namespace RufaPoint.Data.Mapping.Shipping
{
    /// <summary>
    /// Mapping class
    /// </summary>
    public partial class ShipmentMap : NopEntityTypeConfiguration<Shipment>
    {
        /// <summary>
        /// Ctor
        /// </summary>
        public ShipmentMap()
        {
            //this.ToTable("Shipment");
            //this.HasKey(s => s.Id);

            //this.Property(s => s.TotalWeight).HasPrecision(18, 4);

            //this.HasRequired(s => s.Order)
            //    .WithMany(o => o.Shipments)
            //    .HasForeignKey(s => s.OrderId);
        }
        protected override void DoConfig(EntityTypeBuilder<Shipment> builder)
        {
            builder.ToTable("Shipment").HasKey(s => s.Id);

           // builder.Property(s => s.TotalWeight).HasPrecision(18, 4);
            builder.HasOne(s => s.Order)
                .WithMany(o => o.Shipments)
                .HasForeignKey(s => s.OrderId);
        }
    }
}