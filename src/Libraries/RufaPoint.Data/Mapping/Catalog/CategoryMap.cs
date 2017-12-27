using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RufaPoint.Core.Domain.Catalog;

namespace RufaPoint.Data.Mapping.Catalog
{
    /// <summary>
    /// Mapping class
    /// </summary>
    public partial class CategoryMap : NopEntityTypeConfiguration<Category>
    {
        /// <summary>
        /// Ctor
        /// </summary>
        public CategoryMap()
        {
          /*  this.ToTable("Category");
            this.HasKey(c => c.Id);
            this.Property(c => c.Name).IsRequired().HasMaxLength(400);
            this.Property(c => c.MetaKeywords).HasMaxLength(400);
            this.Property(c => c.MetaTitle).HasMaxLength(400);
            this.Property(c => c.PriceRanges).HasMaxLength(400);
            this.Property(c => c.PageSizeOptions).HasMaxLength(200);*/
        }
        protected override void DoConfig(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Category").HasKey(c => c.Id);
            builder.Property(c => c.Name).IsRequired().HasMaxLength(400);
            builder.Property(c => c.MetaKeywords).HasMaxLength(400);
            builder.Property(c => c.MetaTitle).HasMaxLength(400);
            builder.Property(c => c.PriceRanges).HasMaxLength(400);
            builder.Property(c => c.PageSizeOptions).HasMaxLength(200);
            builder.Ignore(i => i.AppliedDiscounts);//Pekmez
        }
    }
}