using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RufaPoint.Core.Domain.Forums;

namespace RufaPoint.Data.Mapping.Forums
{
    /// <summary>
    /// Mapping class
    /// </summary>
    public partial class ForumPostMap : NopEntityTypeConfiguration<ForumPost>
    {
        /// <summary>
        /// Ctor
        /// </summary>
        public ForumPostMap()
        {
            //this.ToTable("Forums_Post");
            //this.HasKey(fp => fp.Id);
            //this.Property(fp => fp.Text).IsRequired();
            //this.Property(fp => fp.IPAddress).HasMaxLength(100);

            //this.HasRequired(fp => fp.ForumTopic)
            //    .WithMany()
            //    .HasForeignKey(fp => fp.TopicId);

            //this.HasRequired(fp => fp.Customer)
            //   .WithMany()
            //   .HasForeignKey(fp => fp.CustomerId)
            //   .WillCascadeOnDelete(false);
        }
        protected override void DoConfig(EntityTypeBuilder<ForumPost> builder)
        {
            builder.ToTable("Forums_Post").HasKey(fp => fp.Id);
            builder.Property(fp => fp.Text).IsRequired();
            builder.Property(fp => fp.IPAddress).HasMaxLength(100);

            builder.HasOne(fp => fp.ForumTopic)
                .WithMany()
                .HasForeignKey(fp => fp.TopicId);

            builder.HasOne(fp => fp.Customer)
               .WithMany()
               .HasForeignKey(fp => fp.CustomerId)
               .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
