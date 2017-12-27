using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RufaPoint.Core.Domain.Logging;

namespace RufaPoint.Data.Mapping.Logging
{
    /// <summary>
    /// Mapping class
    /// </summary>
    public partial class ActivityLogTypeMap : NopEntityTypeConfiguration<ActivityLogType>
    {
        /// <summary>
        /// Ctor
        /// </summary>
        public ActivityLogTypeMap()
        {
            //this.ToTable("ActivityLogType");
            //this.HasKey(alt => alt.Id);

            //this.Property(alt => alt.SystemKeyword).IsRequired().HasMaxLength(100);
            //this.Property(alt => alt.Name).IsRequired().HasMaxLength(200);
        }
        protected override void DoConfig(EntityTypeBuilder<ActivityLogType> builder)
        {
            builder.ToTable("ActivityLogType").HasKey(alt => alt.Id);

            builder.Property(alt => alt.SystemKeyword).IsRequired().HasMaxLength(100);
            builder.Property(alt => alt.Name).IsRequired().HasMaxLength(200);
        }
    }
}
