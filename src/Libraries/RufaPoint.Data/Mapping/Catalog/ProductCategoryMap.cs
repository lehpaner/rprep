using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RufaPoint.Core.Domain.Catalog;

namespace RufaPoint.Data.Mapping.Catalog
{
    /// <summary>
    /// Mapping class
    /// </summary>
    public partial class ProductCategoryMap : NopEntityTypeConfiguration<ProductCategory>
    {
        /// <summary>
        /// Ctor
        /// </summary>
        public ProductCategoryMap()
        {
            //this.ToTable("Product_Category_Mapping");
            //this.HasKey(pc => pc.Id);

            //this.HasRequired(pc => pc.Category)
            //    .WithMany()
            //    .HasForeignKey(pc => pc.CategoryId);


            //this.HasRequired(pc => pc.Product)
            //    .WithMany(p => p.ProductCategories)
            //    .HasForeignKey(pc => pc.ProductId);
        }
        protected override void DoConfig(EntityTypeBuilder<ProductCategory> builder)
        {
            builder.ToTable("Product_Category_Mapping").HasKey(pc => pc.Id);

            builder.HasOne(pc => pc.Category)
                .WithMany()
                .HasForeignKey(pc => pc.CategoryId);


            builder.HasOne(pc => pc.Product)
                .WithMany(p => p.ProductCategories)
                .HasForeignKey(pc => pc.ProductId);
        }
    }
}