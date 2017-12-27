using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RufaPoint.Core.Domain.Logging;

namespace RufaPoint.Data.Mapping.Logging
{
    /// <summary>
    /// Mapping class
    /// </summary>
    public partial class LogMap : NopEntityTypeConfiguration<Log>
    {
        /// <summary>
        /// Ctor
        /// </summary>
        public LogMap()
        {
            //this.ToTable("Log");
            //this.HasKey(l => l.Id);
            //this.Property(l => l.ShortMessage).IsRequired();
            //this.Property(l => l.IpAddress).HasMaxLength(200);

            //this.Ignore(l => l.LogLevel);

            //this.HasOptional(l => l.Customer)
            //    .WithMany()
            //    .HasForeignKey(l => l.CustomerId)
            //.WillCascadeOnDelete(true);
        }
        protected override void DoConfig(EntityTypeBuilder<Log> builder)
        {
            builder.ToTable("Log").HasKey(l => l.Id);
            builder.Property(l => l.ShortMessage).IsRequired();
            builder.Property(l => l.IpAddress).HasMaxLength(200);

            builder.Ignore(l => l.LogLevel);

            builder.HasOne(l => l.Customer)
                .WithMany()
                .HasForeignKey(l => l.CustomerId)
            .OnDelete(DeleteBehavior.Cascade);
        }
    }
}