using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RufaPoint.Core.Domain.Messages;

namespace RufaPoint.Data.Mapping.Messages
{
    /// <summary>
    /// Mapping class
    /// </summary>
    public partial class MessageTemplateMap : NopEntityTypeConfiguration<MessageTemplate>
    {
        /// <summary>
        /// Ctor
        /// </summary>
        public MessageTemplateMap()
        {
            //this.ToTable("MessageTemplate");
            //this.HasKey(mt => mt.Id);

            //this.Property(mt => mt.Name).IsRequired().HasMaxLength(200);
            //this.Property(mt => mt.BccEmailAddresses).HasMaxLength(200);
            //this.Property(mt => mt.Subject).HasMaxLength(1000);
            //this.Property(mt => mt.EmailAccountId).IsRequired();

            //this.Ignore(mt => mt.DelayPeriod);
        }
        protected override void DoConfig(EntityTypeBuilder<MessageTemplate> builder)
        {
            builder.ToTable("MessageTemplate").HasKey(mt => mt.Id);

            builder.Property(mt => mt.Name).IsRequired().HasMaxLength(200);
            builder.Property(mt => mt.BccEmailAddresses).HasMaxLength(200);
            builder.Property(mt => mt.Subject).HasMaxLength(1000);
            builder.Property(mt => mt.EmailAccountId).IsRequired();

            builder.Ignore(mt => mt.DelayPeriod);
        }
    }
}