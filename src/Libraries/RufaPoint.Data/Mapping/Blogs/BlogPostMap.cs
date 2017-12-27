using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RufaPoint.Core.Domain.Blogs;

namespace RufaPoint.Data.Mapping.Blogs
{
    /// <summary>
    /// Mapping class
    /// </summary>
    public partial class BlogPostMap : NopEntityTypeConfiguration<BlogPost>
    {
        /// <summary>
        /// Ctor
        /// </summary>
        public BlogPostMap()
        {
            /*  this.ToTable("BlogPost");
              this.HasKey(bp => bp.Id);
              this.Property(bp => bp.Title).IsRequired();
              this.Property(bp => bp.Body).IsRequired();
              this.Property(bp => bp.MetaKeywords).HasMaxLength(400);
              this.Property(bp => bp.MetaTitle).HasMaxLength(400);

              this.HasRequired(bp => bp.Language)
                  .WithMany()
                  .HasForeignKey(bp => bp.LanguageId).WillCascadeOnDelete(true);*/
        }
        protected override void DoConfig(EntityTypeBuilder<BlogPost> builder)
        {
            builder.ToTable("BlogPost").HasKey(a => a.Id);
            builder.Property(bp => bp.Title).IsRequired();
            builder.Property(bp => bp.Body).IsRequired();
            builder.Property(bp => bp.MetaKeywords).HasMaxLength(400);
            builder.Property(bp => bp.MetaTitle).HasMaxLength(400);

            builder.HasOne(bp => bp.Language).WithMany().HasForeignKey(bp => bp.LanguageId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}