using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RufaPoint.Core.Domain.Catalog;

namespace RufaPoint.Data.Mapping.Catalog
{
    /// <summary>
    /// Mapping class
    /// </summary>
    public partial class ProductSpecificationAttributeMap : NopEntityTypeConfiguration<ProductSpecificationAttribute>
    {
        /// <summary>
        /// Ctor
        /// </summary>
        public ProductSpecificationAttributeMap()
        {
            //this.ToTable("Product_SpecificationAttribute_Mapping");
            //this.HasKey(psa => psa.Id);

            //this.Property(psa => psa.CustomValue).HasMaxLength(4000);

            //this.Ignore(psa => psa.AttributeType);

            //this.HasRequired(psa => psa.SpecificationAttributeOption)
            //    .WithMany()
            //    .HasForeignKey(psa => psa.SpecificationAttributeOptionId);


            //this.HasRequired(psa => psa.Product)
            //    .WithMany(p => p.ProductSpecificationAttributes)
            //    .HasForeignKey(psa => psa.ProductId);
        }
        protected override void DoConfig(EntityTypeBuilder<ProductSpecificationAttribute> builder)
        {
            builder.ToTable("Product_SpecificationAttribute_Mapping").HasKey(psa => psa.Id);

            builder.Property(psa => psa.CustomValue).HasMaxLength(4000);

            builder.Ignore(psa => psa.AttributeType);

            builder.HasOne(psa => psa.SpecificationAttributeOption)
                .WithMany()
                .HasForeignKey(psa => psa.SpecificationAttributeOptionId);


            builder.HasOne(psa => psa.Product)
                .WithMany(p => p.ProductSpecificationAttributes)
                .HasForeignKey(psa => psa.ProductId);
        }
    }
}