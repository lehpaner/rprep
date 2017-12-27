using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RufaPoint.Core.Domain.News;

namespace RufaPoint.Data.Mapping.News
{
    /// <summary>
    /// Mapping class
    /// </summary>
    public partial class NewsItemMap : NopEntityTypeConfiguration<NewsItem>
    {
        /// <summary>
        /// Ctor
        /// </summary>
        public NewsItemMap()
        {
            //this.ToTable("News");
            //this.HasKey(ni => ni.Id);
            //this.Property(ni => ni.Title).IsRequired();
            //this.Property(ni => ni.Short).IsRequired();
            //this.Property(ni => ni.Full).IsRequired();
            //this.Property(ni => ni.MetaKeywords).HasMaxLength(400);
            //this.Property(ni => ni.MetaTitle).HasMaxLength(400);

            //this.HasRequired(ni => ni.Language)
            //    .WithMany()
            //    .HasForeignKey(ni => ni.LanguageId).WillCascadeOnDelete(true);
        }
        protected override void DoConfig(EntityTypeBuilder<NewsItem> builder)
        {
            builder.ToTable("News").HasKey(ni => ni.Id);
            builder.Property(ni => ni.Title).IsRequired();
            builder.Property(ni => ni.Short).IsRequired();
            builder.Property(ni => ni.Full).IsRequired();
            builder.Property(ni => ni.MetaKeywords).HasMaxLength(400);
            builder.Property(ni => ni.MetaTitle).HasMaxLength(400);

            builder.HasOne(ni => ni.Language)
                .WithMany()
                .HasForeignKey(ni => ni.LanguageId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}