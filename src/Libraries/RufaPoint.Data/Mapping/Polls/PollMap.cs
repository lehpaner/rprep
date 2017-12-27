using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RufaPoint.Core.Domain.Polls;

namespace RufaPoint.Data.Mapping.Polls
{
    /// <summary>
    /// Mapping class
    /// </summary>
    public partial class PollMap : NopEntityTypeConfiguration<Poll>
    {
        /// <summary>
        /// Ctor
        /// </summary>
        public PollMap()
        {
            //this.ToTable("Poll");
            //this.HasKey(p => p.Id);
            //this.Property(p => p.Name).IsRequired();

            //this.HasRequired(p => p.Language)
            //    .WithMany()
            //    .HasForeignKey(p => p.LanguageId).WillCascadeOnDelete(true);
        }
        protected override void DoConfig(EntityTypeBuilder<Poll> builder)
        {
            builder.ToTable("Poll").HasKey(p => p.Id);
            builder.Property(p => p.Name).IsRequired();

            builder.HasOne(p => p.Language)
                .WithMany()
                .HasForeignKey(p => p.LanguageId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}