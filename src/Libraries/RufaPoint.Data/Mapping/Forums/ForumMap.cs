using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RufaPoint.Core.Domain.Forums;

namespace RufaPoint.Data.Mapping.Forums
{
    /// <summary>
    /// Mapping class
    /// </summary>
    public partial class ForumMap : NopEntityTypeConfiguration<Forum>
    {
        /// <summary>
        /// Ctor
        /// </summary>
        public ForumMap()
        {
            //this.ToTable("Forums_Forum");
            //this.HasKey(f => f.Id);
            //this.Property(f => f.Name).IsRequired().HasMaxLength(200);

            //this.HasRequired(f => f.ForumGroup)
            //    .WithMany(fg => fg.Forums)
            //    .HasForeignKey(f => f.ForumGroupId);
        }
        protected override void DoConfig(EntityTypeBuilder<Forum> builder)
        {
            builder.ToTable("Forums_Forum").HasKey(f => f.Id);
            builder.Property(f => f.Name).IsRequired().HasMaxLength(200);

            builder.HasOne(f => f.ForumGroup)
                .WithMany(fg => fg.Forums)
                .HasForeignKey(f => f.ForumGroupId);
        }
    }
}
