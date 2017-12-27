using RufaPoint.Core.Domain.Messages;

namespace RufaPoint.Data.Mapping.Messages
{
    /// <summary>
    /// Mapping class
    /// </summary>
    public partial class QueuedEmailMap : NopEntityTypeConfiguration<QueuedEmail>
    {
        /// <summary>
        /// Ctor
        /// </summary>
        public QueuedEmailMap()
        {
            this.ToTable("QueuedEmail");
            this.HasKey(qe => qe.Id);

            this.Property(qe => qe.From).IsRequired().HasMaxLength(500);
            this.Property(qe => qe.FromName).HasMaxLength(500);
            this.Property(qe => qe.To).IsRequired().HasMaxLength(500);
            this.Property(qe => qe.ToName).HasMaxLength(500);
            this.Property(qe => qe.ReplyTo).HasMaxLength(500);
            this.Property(qe => qe.ReplyToName).HasMaxLength(500);
            this.Property(qe => qe.CC).HasMaxLength(500);
            this.Property(qe => qe.Bcc).HasMaxLength(500);
            this.Property(qe => qe.Subject).HasMaxLength(1000);


            this.Ignore(qe => qe.Priority);

            this.HasRequired(qe => qe.EmailAccount)
                .WithMany()
                .HasForeignKey(qe => qe.EmailAccountId).WillCascadeOnDelete(true);
        }
    }
}