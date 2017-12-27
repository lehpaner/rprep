using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RufaPoint.Core.Domain.Catalog;

namespace RufaPoint.Data.Mapping.Catalog
{
    /// <summary>
    /// Mapping class
    /// </summary>
    public partial class ProductAttributeMap : NopEntityTypeConfiguration<ProductAttribute>
    {
        /// <summary>
        /// Ctor
        /// </summary>
        public ProductAttributeMap()
        {
           /* this.ToTable("ProductAttribute");
            this.HasKey(pa => pa.Id);
            this.Property(pa => pa.Name).IsRequired();*/
        }
        protected override void DoConfig(EntityTypeBuilder<ProductAttribute> builder)
        {
            builder.ToTable("ProductAttribute").HasKey(pa => pa.Id);
            builder.Property(pa => pa.Name).IsRequired();
        }
    }
}