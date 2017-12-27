using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RufaPoint.Core.Domain.Catalog;

namespace RufaPoint.Data.Mapping.Catalog
{
    /// <summary>
    /// Mapping class
    /// </summary>
    public partial class ManufacturerTemplateMap : NopEntityTypeConfiguration<ManufacturerTemplate>
    {
        /// <summary>
        /// Ctor
        /// </summary>
        public ManufacturerTemplateMap()
        {
            /* this.ToTable("ManufacturerTemplate");
             this.HasKey(p => p.Id);
             this.Property(p => p.Name).IsRequired().HasMaxLength(400);
             this.Property(p => p.ViewPath).IsRequired().HasMaxLength(400);*/
        }
        protected override void DoConfig(EntityTypeBuilder<ManufacturerTemplate> builder)
        {
            builder.ToTable("ManufacturerTemplate").HasKey(p => p.Id);
            builder.Property(p => p.Name).IsRequired().HasMaxLength(400);
            builder.Property(p => p.ViewPath).IsRequired().HasMaxLength(400);
        }
    }
}