using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RufaPoint.Core.Domain.News;

namespace RufaPoint.Data.Mapping.News
{
    /// <summary>
    /// Mapping class
    /// </summary>
    public partial class NewsCommentMap : NopEntityTypeConfiguration<NewsComment>
    {
        /// <summary>
        /// Ctor
        /// </summary>
        public NewsCommentMap()
        {
            //this.ToTable("NewsComment");
            //this.HasKey(comment => comment.Id);

            //this.HasRequired(comment => comment.NewsItem)
            //    .WithMany(news => news.NewsComments)
            //    .HasForeignKey(comment => comment.NewsItemId);

            //this.HasRequired(comment => comment.Customer)
            //    .WithMany()
            //    .HasForeignKey(comment => comment.CustomerId);

            //this.HasRequired(comment => comment.Store)
            //    .WithMany()
            //    .HasForeignKey(comment => comment.StoreId);
        }
        protected override void DoConfig(EntityTypeBuilder<NewsComment> builder)
        {
            builder.ToTable("NewsComment").HasKey(comment => comment.Id);

            builder.HasOne(comment => comment.NewsItem)
                .WithMany(news => news.NewsComments)
                .HasForeignKey(comment => comment.NewsItemId);

            builder.HasOne(comment => comment.Customer)
                .WithMany()
                .HasForeignKey(comment => comment.CustomerId);

            builder.HasOne(comment => comment.Store)
                .WithMany()
                .HasForeignKey(comment => comment.StoreId);
        }
    }
}