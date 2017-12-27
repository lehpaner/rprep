using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RufaPoint.Core.Domain.Shipping;

namespace RufaPoint.Data.Mapping.Shipping
{
    /// <summary>
    /// Mapping class
    /// </summary>
    public class ProductAvailabilityRangeMap : NopEntityTypeConfiguration<ProductAvailabilityRange>
    {
        /// <summary>
        /// Ctor
        /// </summary>
        public ProductAvailabilityRangeMap()
        {
            //this.ToTable("ProductAvailabilityRange");
            //this.HasKey(range => range.Id);
            //this.Property(range => range.Name).IsRequired().HasMaxLength(400);
        }
        protected override void DoConfig(EntityTypeBuilder<ProductAvailabilityRange> builder)
        {
            builder.ToTable("ProductAvailabilityRange").HasKey(range => range.Id);
            builder.Property(range => range.Name).IsRequired().HasMaxLength(400);
        }
    }
}
