using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RufaPoint.Core.Domain.Polls;

namespace RufaPoint.Data.Mapping.Polls
{
    /// <summary>
    /// Mapping class
    /// </summary>
    public partial class PollAnswerMap : NopEntityTypeConfiguration<PollAnswer>
    {
        /// <summary>
        /// Ctor
        /// </summary>
        public PollAnswerMap()
        {
            //this.ToTable("PollAnswer");
            //this.HasKey(pa => pa.Id);
            //this.Property(pa => pa.Name).IsRequired();

            //this.HasRequired(pa => pa.Poll)
            //    .WithMany(p => p.PollAnswers)
            //    .HasForeignKey(pa => pa.PollId).WillCascadeOnDelete(true);
        }
        protected override void DoConfig(EntityTypeBuilder<PollAnswer> builder)
        {
            builder.ToTable("PollAnswer").HasKey(pa => pa.Id);
            builder.Property(pa => pa.Name).IsRequired();

            builder.HasOne(pa => pa.Poll)
                .WithMany(p => p.PollAnswers)
                .HasForeignKey(pa => pa.PollId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}