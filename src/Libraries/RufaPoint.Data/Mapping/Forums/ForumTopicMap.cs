using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RufaPoint.Core.Domain.Forums;

namespace RufaPoint.Data.Mapping.Forums
{
    /// <summary>
    /// Mapping class
    /// </summary>
    public partial class ForumTopicMap : NopEntityTypeConfiguration<ForumTopic>
    {
        /// <summary>
        /// Ctor
        /// </summary>
        public ForumTopicMap()
        {
            //this.ToTable("Forums_Topic");
            //this.HasKey(ft => ft.Id);
            //this.Property(ft => ft.Subject).IsRequired().HasMaxLength(450);
            //this.Ignore(ft => ft.ForumTopicType);

            //this.HasRequired(ft => ft.Forum)
            //    .WithMany()
            //    .HasForeignKey(ft => ft.ForumId);

            //this.HasRequired(ft => ft.Customer)
            //   .WithMany()
            //   .HasForeignKey(ft => ft.CustomerId)
            //   .WillCascadeOnDelete(false);
        }
        protected override void DoConfig(EntityTypeBuilder<ForumTopic> builder)
        {
            builder.ToTable("Forums_Topic").HasKey(ft => ft.Id);
            builder.Property(ft => ft.Subject).IsRequired().HasMaxLength(450);
            builder.Ignore(ft => ft.ForumTopicType);

            builder.HasOne(ft => ft.Forum)
                .WithMany()
                .HasForeignKey(ft => ft.ForumId);

            builder.HasOne(ft => ft.Customer)
               .WithMany()
               .HasForeignKey(ft => ft.CustomerId)
               .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
