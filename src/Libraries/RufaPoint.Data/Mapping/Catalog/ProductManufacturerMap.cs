using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RufaPoint.Core.Domain.Catalog;

namespace RufaPoint.Data.Mapping.Catalog
{
    /// <summary>
    /// Mapping class
    /// </summary>
    public partial class ProductManufacturerMap : NopEntityTypeConfiguration<ProductManufacturer>
    {
        /// <summary>
        /// Ctor
        /// </summary>
        public ProductManufacturerMap()
        {
            //this.ToTable("Product_Manufacturer_Mapping");
            //this.HasKey(pm => pm.Id);

            //this.HasRequired(pm => pm.Manufacturer)
            //    .WithMany()
            //    .HasForeignKey(pm => pm.ManufacturerId);


            //this.HasRequired(pm => pm.Product)
            //    .WithMany(p => p.ProductManufacturers)
            //    .HasForeignKey(pm => pm.ProductId);
        }
        protected override void DoConfig(EntityTypeBuilder<ProductManufacturer> builder)
        {
            builder.ToTable("Product_Manufacturer_Mapping").HasKey(pm => pm.Id);

            builder.HasOne(pm => pm.Manufacturer)
                .WithMany()
                .HasForeignKey(pm => pm.ManufacturerId);


            builder.HasOne(pm => pm.Product)
                .WithMany(p => p.ProductManufacturers)
                .HasForeignKey(pm => pm.ProductId);
        }
    }
}