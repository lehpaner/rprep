using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RufaPoint.Core.Domain.Polls;

namespace RufaPoint.Data.Mapping.Polls
{
    /// <summary>
    /// Mapping class
    /// </summary>
    public partial class PollVotingRecordMap : NopEntityTypeConfiguration<PollVotingRecord>
    {
        /// <summary>
        /// Ctor
        /// </summary>
        public PollVotingRecordMap()
        {
            //this.ToTable("PollVotingRecord");
            //this.HasKey(pr => pr.Id);

            //this.HasRequired(pvr => pvr.PollAnswer)
            //    .WithMany(pa => pa.PollVotingRecords)
            //    .HasForeignKey(pvr => pvr.PollAnswerId);

            //this.HasRequired(cc => cc.Customer)
            //    .WithMany()
            //    .HasForeignKey(cc => cc.CustomerId);
        }
        protected override void DoConfig(EntityTypeBuilder<PollVotingRecord> builder)
        {
            builder.ToTable("PollVotingRecord").HasKey(pr => pr.Id);

            builder.HasOne(pvr => pvr.PollAnswer)
                .WithMany(pa => pa.PollVotingRecords)
                .HasForeignKey(pvr => pvr.PollAnswerId);

            builder.HasOne(cc => cc.Customer)
                .WithMany()
                .HasForeignKey(cc => cc.CustomerId);
        }
    }
}