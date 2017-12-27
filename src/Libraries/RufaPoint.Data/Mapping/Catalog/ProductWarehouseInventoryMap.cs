using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RufaPoint.Core.Domain.Catalog;

namespace RufaPoint.Data.Mapping.Catalog
{
    /// <summary>
    /// Mapping class
    /// </summary>
    public partial class ProductWarehouseInventoryMap : NopEntityTypeConfiguration<ProductWarehouseInventory>
    {
        /// <summary>
        /// Ctor
        /// </summary>
        public ProductWarehouseInventoryMap()
        {
            //this.ToTable("ProductWarehouseInventory");
            //this.HasKey(x => x.Id);

            //this.HasRequired(x => x.Product)
            //    .WithMany(p => p.ProductWarehouseInventory)
            //    .HasForeignKey(x => x.ProductId)
            //    .WillCascadeOnDelete(true);

            //this.HasRequired(x => x.Warehouse)
            //    .WithMany()
            //    .HasForeignKey(x => x.WarehouseId)
            //    .WillCascadeOnDelete(true);
        }
        protected override void DoConfig(EntityTypeBuilder<ProductWarehouseInventory> builder)
        {
            builder.ToTable("ProductWarehouseInventory").HasKey(x => x.Id);

            builder.HasOne(x => x.Product)
                .WithMany(p => p.ProductWarehouseInventory)
                .HasForeignKey(x => x.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Warehouse)
                .WithMany()
                .HasForeignKey(x => x.WarehouseId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}