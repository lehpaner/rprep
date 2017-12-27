using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RufaPoint.Core.Domain.Directory;

namespace RufaPoint.Data.Mapping.Directory
{
    /// <summary>
    /// Mapping class
    /// </summary>
    public partial class MeasureWeightMap : NopEntityTypeConfiguration<MeasureWeight>
    {
        /// <summary>
        /// Ctor
        /// </summary>
        public MeasureWeightMap()
        {
            //this.ToTable("MeasureWeight");
            //this.HasKey(m => m.Id);
            //this.Property(m => m.Name).IsRequired().HasMaxLength(100);
            //this.Property(m => m.SystemKeyword).IsRequired().HasMaxLength(100);
            //this.Property(m => m.Ratio).HasPrecision(18, 8);
        }
        protected override void DoConfig(EntityTypeBuilder<MeasureWeight> builder)
        {
            builder.ToTable("MeasureWeight").HasKey(m => m.Id);
            builder.Property(m => m.Name).IsRequired().HasMaxLength(100);
            builder.Property(m => m.SystemKeyword).IsRequired().HasMaxLength(100);
            //builder.Property(m => m.Ratio).HasPrecision(18, 8);
        }
    }
}