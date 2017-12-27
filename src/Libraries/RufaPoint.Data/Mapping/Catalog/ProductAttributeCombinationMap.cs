using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RufaPoint.Core.Domain.Catalog;

namespace RufaPoint.Data.Mapping.Catalog
{
    /// <summary>
    /// Mapping class
    /// </summary>
    public partial class ProductAttributeCombinationMap : NopEntityTypeConfiguration<ProductAttributeCombination>
    {
        /// <summary>
        /// Ctor
        /// </summary>
        public ProductAttributeCombinationMap()
        {
            /*this.ToTable("ProductAttributeCombination");
            this.HasKey(pac => pac.Id);

            this.Property(pac => pac.Sku).HasMaxLength(400);
            this.Property(pac => pac.ManufacturerPartNumber).HasMaxLength(400);
            this.Property(pac => pac.Gtin).HasMaxLength(400);
            this.Property(pac => pac.OverriddenPrice).HasPrecision(18, 4);

            this.HasRequired(pac => pac.Product)
                .WithMany(p => p.ProductAttributeCombinations)
                .HasForeignKey(pac => pac.ProductId);*/
        }
        protected override void DoConfig(EntityTypeBuilder<ProductAttributeCombination> builder)
        {
            builder.ToTable("ProductAttributeCombination").HasKey(pac => pac.Id);

            builder.Property(pac => pac.Sku).HasMaxLength(400);
            builder.Property(pac => pac.ManufacturerPartNumber).HasMaxLength(400);
            builder.Property(pac => pac.Gtin).HasMaxLength(400);
           // builder.Property(pac => pac.OverriddenPrice).HasPrecision(18, 4);

            builder.HasOne(pac => pac.Product)
                .WithMany(p => p.ProductAttributeCombinations)
                .HasForeignKey(pac => pac.ProductId);
        }
    }
}