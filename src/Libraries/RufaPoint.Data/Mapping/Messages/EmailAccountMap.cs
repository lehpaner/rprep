using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RufaPoint.Core.Domain.Messages;

namespace RufaPoint.Data.Mapping.Messages
{
    /// <summary>
    /// Mapping class
    /// </summary>
    public partial class EmailAccountMap : NopEntityTypeConfiguration<EmailAccount>
    {
        /// <summary>
        /// Ctor
        /// </summary>
        public EmailAccountMap()
        {
            //this.ToTable("EmailAccount");
            //this.HasKey(ea => ea.Id);

            //this.Property(ea => ea.Email).IsRequired().HasMaxLength(255);
            //this.Property(ea => ea.DisplayName).HasMaxLength(255);
            //this.Property(ea => ea.Host).IsRequired().HasMaxLength(255);
            //this.Property(ea => ea.Username).IsRequired().HasMaxLength(255);
            //this.Property(ea => ea.Password).IsRequired().HasMaxLength(255);

            //this.Ignore(ea => ea.FriendlyName);
        }
        protected override void DoConfig(EntityTypeBuilder<EmailAccount> builder)
        {
            builder.ToTable("EmailAccount").HasKey(ea => ea.Id);

            builder.Property(ea => ea.Email).IsRequired().HasMaxLength(255);
            builder.Property(ea => ea.DisplayName).HasMaxLength(255);
            builder.Property(ea => ea.Host).IsRequired().HasMaxLength(255);
            builder.Property(ea => ea.Username).IsRequired().HasMaxLength(255);
            builder.Property(ea => ea.Password).IsRequired().HasMaxLength(255);

            builder.Ignore(ea => ea.FriendlyName);
        }
    }
}