using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RufaPoint.Core.Domain.Logging;

namespace RufaPoint.Data.Mapping.Logging
{
    /// <summary>
    /// Mapping class
    /// </summary>
    public partial class ActivityLogMap : NopEntityTypeConfiguration<ActivityLog>
    {
        /// <summary>
        /// Ctor
        /// </summary>
        public ActivityLogMap()
        {
            //this.ToTable("ActivityLog");
            //this.HasKey(al => al.Id);
            //this.Property(al => al.Comment).IsRequired();
            //this.Property(al => al.IpAddress).HasMaxLength(200);

            //this.HasRequired(al => al.ActivityLogType)
            //    .WithMany()
            //    .HasForeignKey(al => al.ActivityLogTypeId);

            //this.HasRequired(al => al.Customer)
            //    .WithMany()
            //    .HasForeignKey(al => al.CustomerId);
        }
        protected override void DoConfig(EntityTypeBuilder<ActivityLog> builder)
        {
            builder.ToTable("ActivityLog").HasKey(al => al.Id);
            builder.Property(al => al.Comment).IsRequired();
            builder.Property(al => al.IpAddress).HasMaxLength(200);

            builder.HasOne(al => al.ActivityLogType)
                .WithMany()
                .HasForeignKey(al => al.ActivityLogTypeId);

            builder.HasOne(al => al.Customer)
                .WithMany()
                .HasForeignKey(al => al.CustomerId);
        }
    }
}
