using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RufaPoint.Core.Domain.Catalog;

namespace RufaPoint.Data.Mapping.Catalog
{
    /// <summary>
    /// Mapping class
    /// </summary>
    public partial class ProductReviewMap : NopEntityTypeConfiguration<ProductReview>
    {
        /// <summary>
        /// Ctor
        /// </summary>
        public ProductReviewMap()
        {
            //this.ToTable("ProductReview");
            //this.HasKey(pr => pr.Id);

            //this.HasRequired(pr => pr.Product)
            //    .WithMany(p => p.ProductReviews)
            //    .HasForeignKey(pr => pr.ProductId);

            //this.HasRequired(pr => pr.Customer)
            //    .WithMany()
            //    .HasForeignKey(pr => pr.CustomerId);

            //this.HasRequired(pr => pr.Store)
            //    .WithMany()
            //    .HasForeignKey(pr => pr.StoreId);
        }
        protected override void DoConfig(EntityTypeBuilder<ProductReview> builder)
        {
            builder.ToTable("ProductReview").HasKey(pr => pr.Id);

            builder.HasOne(pr => pr.Product)
                .WithMany(p => p.ProductReviews)
                .HasForeignKey(pr => pr.ProductId);

            builder.HasOne(pr => pr.Customer)
                .WithMany()
                .HasForeignKey(pr => pr.CustomerId);

            builder.HasOne(pr => pr.Store)
                .WithMany()
                .HasForeignKey(pr => pr.StoreId);
        }
    }
}