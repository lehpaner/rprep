using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RufaPoint.Core.Domain.Directory;

namespace RufaPoint.Data.Mapping.Directory
{
    /// <summary>
    /// Mapping class
    /// </summary>
    public partial class MeasureDimensionMap : NopEntityTypeConfiguration<MeasureDimension>
    {
        /// <summary>
        /// Ctor
        /// </summary>
        public MeasureDimensionMap()
        {
            //this.ToTable("MeasureDimension");
            //this.HasKey(m => m.Id);
            //this.Property(m => m.Name).IsRequired().HasMaxLength(100);
            //this.Property(m => m.SystemKeyword).IsRequired().HasMaxLength(100);
            //this.Property(m => m.Ratio).HasPrecision(18, 8);
        }
        protected override void DoConfig(EntityTypeBuilder<MeasureDimension> builder)
        {
            builder.ToTable("MeasureDimension").HasKey(m => m.Id);
            builder.Property(m => m.Name).IsRequired().HasMaxLength(100);
            builder.Property(m => m.SystemKeyword).IsRequired().HasMaxLength(100);
            //builder.Property(m => m.Ratio).HasPrecision(18, 8);
        }
    }
}