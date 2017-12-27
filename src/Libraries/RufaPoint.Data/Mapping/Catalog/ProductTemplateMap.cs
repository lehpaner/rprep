using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RufaPoint.Core.Domain.Catalog;

namespace RufaPoint.Data.Mapping.Catalog
{
    /// <summary>
    /// Mapping class
    /// </summary>
    public partial class ProductTemplateMap : NopEntityTypeConfiguration<ProductTemplate>
    {
        /// <summary>
        /// Ctor
        /// </summary>
        public ProductTemplateMap()
        {
            //this.ToTable("ProductTemplate");
            //this.HasKey(p => p.Id);
            //this.Property(p => p.Name).IsRequired().HasMaxLength(400);
            //this.Property(p => p.ViewPath).IsRequired().HasMaxLength(400);
        }
        protected override void DoConfig(EntityTypeBuilder<ProductTemplate> builder)
        {
            builder.ToTable("ProductTemplate").HasKey(p => p.Id);
            builder.Property(p => p.Name).IsRequired().HasMaxLength(400);
            builder.Property(p => p.ViewPath).IsRequired().HasMaxLength(400);
        }
    }
}