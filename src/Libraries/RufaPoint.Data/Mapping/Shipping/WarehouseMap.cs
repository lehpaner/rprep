using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RufaPoint.Core.Domain.Shipping;

namespace RufaPoint.Data.Mapping.Shipping
{
    /// <summary>
    /// Mapping class
    /// </summary>
    public class WarehouseMap : NopEntityTypeConfiguration<Warehouse>
    {
        /// <summary>
        /// Ctor
        /// </summary>
        public WarehouseMap()
        {
            //this.ToTable("Warehouse");
            //this.HasKey(wh => wh.Id);
            //this.Property(wh => wh.Name).IsRequired().HasMaxLength(400);
        }
        protected override void DoConfig(EntityTypeBuilder<Warehouse> builder)
        {
            builder.ToTable("Warehouse").HasKey(wh => wh.Id);
            builder.Property(wh => wh.Name).IsRequired().HasMaxLength(400);
        }
    }
}
