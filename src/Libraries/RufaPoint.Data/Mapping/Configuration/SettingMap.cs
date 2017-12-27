using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RufaPoint.Core.Domain.Configuration;

namespace RufaPoint.Data.Mapping.Configuration
{
    /// <summary>
    /// Mapping class
    /// </summary>
    public partial class SettingMap : NopEntityTypeConfiguration<Setting>
    {
        /// <summary>
        /// Ctor
        /// </summary>
        public SettingMap()
        {
            //this.ToTable("Setting");
            //this.HasKey(s => s.Id);
            //this.Property(s => s.Name).IsRequired().HasMaxLength(200);
            //this.Property(s => s.Value).IsRequired().HasMaxLength(2000);
        }
        protected override void DoConfig(EntityTypeBuilder<Setting> builder)
        {
            builder.ToTable("Setting").HasKey(s => s.Id);
            builder.Property(s => s.Name).IsRequired().HasMaxLength(200);
            builder.Property(s => s.Value).IsRequired().HasMaxLength(2000);
        }
    }
}