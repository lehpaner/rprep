using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RufaPoint.Core.Domain.Blogs;
using RufaPoint.Core.Domain.Customers;
using RufaPoint.Core.Domain.Stores;

namespace RufaPoint.Data.Mapping.Blogs
{
    /// <summary>
    /// Mapping class
    /// </summary>
    public partial class BlogCommentMap : NopEntityTypeConfiguration<BlogComment>
    {
        /// <summary>
        /// Ctor
        /// </summary>
        public BlogCommentMap()
        {
         /*   this.ToTable("BlogComment");
            this.HasKey(comment => comment.Id);

            this.HasRequired(comment => comment.BlogPost)
                .WithMany(blog => blog.BlogComments)
                .HasForeignKey(comment => comment.BlogPostId);

            this.HasRequired(comment => comment.Customer)
                .WithMany()
                .HasForeignKey(comment => comment.CustomerId);

            this.HasRequired(comment => comment.Store)
                .WithMany()
                .HasForeignKey(comment => comment.StoreId);*/
        }
        protected override void DoConfig(EntityTypeBuilder<BlogComment> builder)
        {
            builder.ToTable("BlogComment").HasKey(k=>k.Id);
            builder.HasOne<BlogPost>(comment => comment.BlogPost).WithMany(blog => blog.BlogComments).HasForeignKey(comment => comment.BlogPostId);
            builder.HasOne<Customer>(comment => comment.Customer).WithMany().HasForeignKey(comment => comment.CustomerId);
            builder.HasOne<Store>(comment => comment.Store).WithMany().HasForeignKey(comment => comment.StoreId);
        }
    }
}