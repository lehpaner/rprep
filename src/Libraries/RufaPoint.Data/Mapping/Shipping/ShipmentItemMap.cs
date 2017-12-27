using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RufaPoint.Core.Domain.Shipping;

namespace RufaPoint.Data.Mapping.Shipping
{
    /// <summary>
    /// Mapping class
    /// </summary>
    public partial class ShipmentItemMap : NopEntityTypeConfiguration<ShipmentItem>
    {
        /// <summary>
        /// Ctor
        /// </summary>
        public ShipmentItemMap()
        {
            //this.ToTable("ShipmentItem");
            //this.HasKey(si => si.Id);

            //this.HasRequired(si => si.Shipment)
            //    .WithMany(s => s.ShipmentItems)
            //    .HasForeignKey(si => si.ShipmentId);
        }
        protected override void DoConfig(EntityTypeBuilder<ShipmentItem> builder)
        {
            builder.ToTable("ShipmentItem").HasKey(si => si.Id);
            builder.HasOne(si => si.Shipment)
                .WithMany(s => s.ShipmentItems)
                .HasForeignKey(si => si.ShipmentId);
        }
    }
}