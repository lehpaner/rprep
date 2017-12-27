using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RufaPoint.Core.Domain.Catalog;

namespace RufaPoint.Data.Mapping.Catalog
{
    /// <summary>
    /// Mapping class
    /// </summary>
    public partial class ProductReviewHelpfulnessMap : NopEntityTypeConfiguration<ProductReviewHelpfulness>
    {
        /// <summary>
        /// Ctor
        /// </summary>
        public ProductReviewHelpfulnessMap()
        {
            //this.ToTable("ProductReviewHelpfulness");
            //this.HasKey(pr => pr.Id);

            //this.HasRequired(prh => prh.ProductReview)
            //    .WithMany(pr => pr.ProductReviewHelpfulnessEntries)
            //    .HasForeignKey(prh => prh.ProductReviewId).WillCascadeOnDelete(true);
        }
        protected override void DoConfig(EntityTypeBuilder<ProductReviewHelpfulness> builder)
        {
            builder.ToTable("ProductReviewHelpfulness").HasKey(pr => pr.Id);

            builder.HasOne(prh => prh.ProductReview)
                .WithMany(pr => pr.ProductReviewHelpfulnessEntries)
                .HasForeignKey(prh => prh.ProductReviewId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}