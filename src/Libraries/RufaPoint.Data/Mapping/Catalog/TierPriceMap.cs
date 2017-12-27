using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RufaPoint.Core.Domain.Catalog;

namespace RufaPoint.Data.Mapping.Catalog
{
    /// <summary>
    /// Mapping class
    /// </summary>
    public partial class TierPriceMap : NopEntityTypeConfiguration<TierPrice>
    {
        /// <summary>
        /// Ctor
        /// </summary>
        public TierPriceMap()
        {
            //this.ToTable("TierPrice");
            //this.HasKey(tp => tp.Id);
            //this.Property(tp => tp.Price).HasPrecision(18, 4);

            //this.HasRequired(tp => tp.Product)
            //    .WithMany(p => p.TierPrices)
            //    .HasForeignKey(tp => tp.ProductId);

            //this.HasOptional(tp => tp.CustomerRole)
            //    .WithMany()
            //    .HasForeignKey(tp => tp.CustomerRoleId)
            //    .WillCascadeOnDelete(true);
        }
        protected override void DoConfig(EntityTypeBuilder<TierPrice> builder)
        {
            builder.ToTable("TierPrice").HasKey(tp => tp.Id);
            //builder.Property(tp => tp.Price).HasPrecision(18, 4);

            builder.HasOne(tp => tp.Product)
                .WithMany(p => p.TierPrices)
                .HasForeignKey(tp => tp.ProductId);

            builder.HasOne(tp => tp.CustomerRole)
                .WithMany()
                .HasForeignKey(tp => tp.CustomerRoleId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}