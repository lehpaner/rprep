using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RufaPoint.Core.Domain.Catalog;

namespace RufaPoint.Data.Mapping.Catalog
{
    /// <summary>
    /// Mapping class
    /// </summary>
    public partial class ProductAttributeValueMap : NopEntityTypeConfiguration<ProductAttributeValue>
    {
        /// <summary>
        /// Ctor
        /// </summary>
        public ProductAttributeValueMap()
        {
            //this.ToTable("ProductAttributeValue");
            //this.HasKey(pav => pav.Id);
            //this.Property(pav => pav.Name).IsRequired().HasMaxLength(400);
            //this.Property(pav => pav.ColorSquaresRgb).HasMaxLength(100);

            //this.Property(pav => pav.PriceAdjustment).HasPrecision(18, 4);
            //this.Property(pav => pav.WeightAdjustment).HasPrecision(18, 4);
            //this.Property(pav => pav.Cost).HasPrecision(18, 4);

            //this.Ignore(pav => pav.AttributeValueType);

            //this.HasRequired(pav => pav.ProductAttributeMapping)
            //    .WithMany(pam => pam.ProductAttributeValues)
            //    .HasForeignKey(pav => pav.ProductAttributeMappingId);
        }
        protected override void DoConfig(EntityTypeBuilder<ProductAttributeValue> builder)
        {
            builder.ToTable("ProductAttributeValue").HasKey(pav => pav.Id);
            builder.Property(pav => pav.Name).IsRequired().HasMaxLength(400);
            builder.Property(pav => pav.ColorSquaresRgb).HasMaxLength(100);

            //builder.Property(pav => pav.PriceAdjustment).HasPrecision(18, 4);
            //builder.Property(pav => pav.WeightAdjustment).HasPrecision(18, 4);
            //builder.Property(pav => pav.Cost).HasPrecision(18, 4);

            builder.Ignore(pav => pav.AttributeValueType);

            builder.HasOne(pav => pav.ProductAttributeMapping)
                .WithMany(pam => pam.ProductAttributeValues)
                .HasForeignKey(pav => pav.ProductAttributeMappingId);
        }
    }
}