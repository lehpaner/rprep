using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RufaPoint.Core.Domain.Catalog;

namespace RufaPoint.Data.Mapping.Catalog
{
    /// <summary>
    /// Mapping class
    /// </summary>
    public partial class PredefinedProductAttributeValueMap : NopEntityTypeConfiguration<PredefinedProductAttributeValue>
    {
        /// <summary>
        /// Ctor
        /// </summary>
        public PredefinedProductAttributeValueMap()
        {
            /*this.ToTable("PredefinedProductAttributeValue");
            this.HasKey(pav => pav.Id);
            this.Property(pav => pav.Name).IsRequired().HasMaxLength(400);

            this.Property(pav => pav.PriceAdjustment).HasPrecision(18, 4);
            this.Property(pav => pav.WeightAdjustment).HasPrecision(18, 4);
            this.Property(pav => pav.Cost).HasPrecision(18, 4);

            this.HasRequired(pav => pav.ProductAttribute)
                .WithMany()
                .HasForeignKey(pav => pav.ProductAttributeId);*/
        }
        protected override void DoConfig(EntityTypeBuilder<PredefinedProductAttributeValue> builder)
        {
            builder.ToTable("PredefinedProductAttributeValue").HasKey(pav => pav.Id);
            builder.Property(pav => pav.Name).IsRequired().HasMaxLength(400);

            //builder.Property(pav => pav.PriceAdjustment).HasPrecision(18, 4);
            //builder.Property(pav => pav.WeightAdjustment).HasPrecision(18, 4);
            //builder.Property(pav => pav.Cost).HasPrecision(18, 4);

            builder.HasOne(pav => pav.ProductAttribute)
                .WithMany()
                .HasForeignKey(pav => pav.ProductAttributeId);
        }
    }
}