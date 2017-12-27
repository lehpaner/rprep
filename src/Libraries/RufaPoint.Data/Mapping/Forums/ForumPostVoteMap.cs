using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RufaPoint.Core.Domain.Forums;

namespace RufaPoint.Data.Mapping.Forums
{
    /// <summary>
    /// Mapping class
    /// </summary>
    public partial class ForumPostVoteMap : NopEntityTypeConfiguration<ForumPostVote>
    {
        /// <summary>
        /// Ctor
        /// </summary>
        public ForumPostVoteMap()
        {
            //this.ToTable("Forums_PostVote");
            //this.HasKey(fpv => fpv.Id);

            //this.HasRequired(fpv => fpv.ForumPost)
            //    .WithMany()
            //    .HasForeignKey(fpv => fpv.ForumPostId)
            //    .WillCascadeOnDelete(true);
        }
        protected override void DoConfig(EntityTypeBuilder<ForumPostVote> builder)
        {
            builder.ToTable("Forums_PostVote").HasKey(fpv => fpv.Id);

            builder.HasOne(fpv => fpv.ForumPost)
                .WithMany()
                .HasForeignKey(fpv => fpv.ForumPostId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
