using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RufaPoint.Core.Domain.Catalog;

namespace RufaPoint.Data.Mapping.Catalog
{
    /// <summary>
    /// Mapping class
    /// </summary>
    public partial class ProductTagMap : NopEntityTypeConfiguration<ProductTag>
    {
        /// <summary>
        /// Ctor
        /// </summary>
        public ProductTagMap()
        {
            //this.ToTable("ProductTag");
            //this.HasKey(pt => pt.Id);
            //this.Property(pt => pt.Name).IsRequired().HasMaxLength(400);
        }
        protected override void DoConfig(EntityTypeBuilder<ProductTag> builder)
        {
            builder.ToTable("ProductTag").HasKey(pt => pt.Id);
            builder.Property(pt => pt.Name).IsRequired().HasMaxLength(400);
            builder.Ignore(i => i.Products);//Pekmez
        }
    }
}