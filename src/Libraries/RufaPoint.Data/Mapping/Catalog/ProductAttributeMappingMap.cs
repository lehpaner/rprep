using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RufaPoint.Core.Domain.Catalog;

namespace RufaPoint.Data.Mapping.Catalog
{
    /// <summary>
    /// Mapping class
    /// </summary>
    public partial class ProductAttributeMappingMap : NopEntityTypeConfiguration<ProductAttributeMapping>
    {
        /// <summary>
        /// Ctor
        /// </summary>
        public ProductAttributeMappingMap()
        {
            /*this.ToTable("Product_ProductAttribute_Mapping");
            this.HasKey(pam => pam.Id);
            this.Ignore(pam => pam.AttributeControlType);

            this.HasRequired(pam => pam.Product)
                .WithMany(p => p.ProductAttributeMappings)
                .HasForeignKey(pam => pam.ProductId);

            this.HasRequired(pam => pam.ProductAttribute)
                .WithMany()
                .HasForeignKey(pam => pam.ProductAttributeId);*/
        }
        protected override void DoConfig(EntityTypeBuilder<ProductAttributeMapping> builder)
        {
            builder.ToTable("Product_ProductAttribute_Mapping").HasKey(pam => pam.Id);
            builder.Ignore(pam => pam.AttributeControlType);

            builder.HasOne(pam => pam.Product)
                .WithMany(p => p.ProductAttributeMappings)
                .HasForeignKey(pam => pam.ProductId);

            builder.HasOne(pam => pam.ProductAttribute)
                .WithMany()
                .HasForeignKey(pam => pam.ProductAttributeId);
        }
    }
}