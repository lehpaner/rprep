using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RufaPoint.Core.Domain.Catalog;

namespace RufaPoint.Data.Mapping.Catalog
{
    /// <summary>
    /// Mapping class
    /// </summary>
    public partial class CrossSellProductMap : NopEntityTypeConfiguration<CrossSellProduct>
    {
        /// <summary>
        /// Ctor
        /// </summary>
        public CrossSellProductMap()
        {
         /*   this.ToTable("CrossSellProduct");
            this.HasKey(c => c.Id);*/
        }
        protected override void DoConfig(EntityTypeBuilder<CrossSellProduct> builder)
        {
            builder.ToTable("CrossSellProduct").HasKey(c => c.Id);
        }
    }
}