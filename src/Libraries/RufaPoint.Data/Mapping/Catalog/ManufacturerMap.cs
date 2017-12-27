using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RufaPoint.Core.Domain.Catalog;

namespace RufaPoint.Data.Mapping.Catalog
{
    /// <summary>
    /// Mapping class
    /// </summary>
    public partial class ManufacturerMap : NopEntityTypeConfiguration<Manufacturer>
    {
        /// <summary>
        /// Ctor
        /// </summary>
        public ManufacturerMap()
        {
            /*this.ToTable("Manufacturer");
            this.HasKey(m => m.Id);
            this.Property(m => m.Name).IsRequired().HasMaxLength(400);
            this.Property(m => m.MetaKeywords).HasMaxLength(400);
            this.Property(m => m.MetaTitle).HasMaxLength(400);
            this.Property(m => m.PriceRanges).HasMaxLength(400);
            this.Property(m => m.PageSizeOptions).HasMaxLength(200);*/
        }
        protected override void DoConfig(EntityTypeBuilder<Manufacturer> builder)
        {
            builder.ToTable("Manufacturer").HasKey(m => m.Id);
            builder.Property(m => m.Name).IsRequired().HasMaxLength(400);
            builder.Property(m => m.MetaKeywords).HasMaxLength(400);
            builder.Property(m => m.MetaTitle).HasMaxLength(400);
            builder.Property(m => m.PriceRanges).HasMaxLength(400);
            builder.Property(m => m.PageSizeOptions).HasMaxLength(200);
            builder.Ignore(i => i.AppliedDiscounts);//Pekmez
        }
    }
}