using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RufaPoint.Core.Domain.Catalog;

namespace RufaPoint.Data.Mapping.Catalog
{
    /// <summary>
    /// Mapping class
    /// </summary>
    public partial class ProductMap : NopEntityTypeConfiguration<Product>
    {
        /// <summary>
        /// Ctor
        /// </summary>
        public ProductMap()
        {
            //this.ToTable("Product");
            //this.HasKey(p => p.Id);
            //this.Property(p => p.Name).IsRequired().HasMaxLength(400);
            //this.Property(p => p.MetaKeywords).HasMaxLength(400);
            //this.Property(p => p.MetaTitle).HasMaxLength(400);
            //this.Property(p => p.Sku).HasMaxLength(400);
            //this.Property(p => p.ManufacturerPartNumber).HasMaxLength(400);
            //this.Property(p => p.Gtin).HasMaxLength(400);
            //this.Property(p => p.AdditionalShippingCharge).HasPrecision(18, 4);
            //this.Property(p => p.Price).HasPrecision(18, 4);
            //this.Property(p => p.OldPrice).HasPrecision(18, 4);
            //this.Property(p => p.ProductCost).HasPrecision(18, 4);
            //this.Property(p => p.MinimumCustomerEnteredPrice).HasPrecision(18, 4);
            //this.Property(p => p.MaximumCustomerEnteredPrice).HasPrecision(18, 4);
            //this.Property(p => p.Weight).HasPrecision(18, 4);
            //this.Property(p => p.Length).HasPrecision(18, 4);
            //this.Property(p => p.Width).HasPrecision(18, 4);
            //this.Property(p => p.Height).HasPrecision(18, 4);
            //this.Property(p => p.RequiredProductIds).HasMaxLength(1000);
            //this.Property(p => p.AllowedQuantities).HasMaxLength(1000);
            //this.Property(p => p.BasepriceAmount).HasPrecision(18, 4);
            //this.Property(p => p.BasepriceBaseAmount).HasPrecision(18, 4);

            //this.Ignore(p => p.ProductType);
            //this.Ignore(p => p.BackorderMode);
            //this.Ignore(p => p.DownloadActivationType);
            //this.Ignore(p => p.GiftCardType);
            //this.Ignore(p => p.LowStockActivity);
            //this.Ignore(p => p.ManageInventoryMethod);
            //this.Ignore(p => p.RecurringCyclePeriod);
            //this.Ignore(p => p.RentalPricePeriod);

            //this.HasMany(p => p.ProductTags)
            //    .WithMany(pt => pt.Products)
            //    .Map(m => m.ToTable("Product_ProductTag_Mapping"));
        }
        protected override void DoConfig(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Product").HasKey(p => p.Id);
            builder.Property(p => p.Name).IsRequired().HasMaxLength(400);
            builder.Property(p => p.MetaKeywords).HasMaxLength(400);
            builder.Property(p => p.MetaTitle).HasMaxLength(400);
            builder.Property(p => p.Sku).HasMaxLength(400);
            builder.Property(p => p.ManufacturerPartNumber).HasMaxLength(400);
            builder.Property(p => p.Gtin).HasMaxLength(400);
            //builder.Property(p => p.AdditionalShippingCharge).HasPrecision(18, 4);
            //builder.Property(p => p.Price).HasPrecision(18, 4);
            //builder.Property(p => p.OldPrice).HasPrecision(18, 4);
            //builder.Property(p => p.ProductCost).HasPrecision(18, 4);
            //builder.Property(p => p.MinimumCustomerEnteredPrice).HasPrecision(18, 4);
            //builder.Property(p => p.MaximumCustomerEnteredPrice).HasPrecision(18, 4);
            //builder.Property(p => p.Weight).HasPrecision(18, 4);
            //builder.Property(p => p.Length).HasPrecision(18, 4);
            //builder.Property(p => p.Width).HasPrecision(18, 4);
            //builder.Property(p => p.Height).HasPrecision(18, 4);
            builder.Property(p => p.RequiredProductIds).HasMaxLength(1000);
            builder.Property(p => p.AllowedQuantities).HasMaxLength(1000);
            //builder.Property(p => p.BasepriceAmount).HasPrecision(18, 4);
            //builder.Property(p => p.BasepriceBaseAmount).HasPrecision(18, 4);

            builder.Ignore(p => p.ProductType);
            builder.Ignore(p => p.BackorderMode);
            builder.Ignore(p => p.DownloadActivationType);
            builder.Ignore(p => p.GiftCardType);
            builder.Ignore(p => p.LowStockActivity);
            builder.Ignore(p => p.ManageInventoryMethod);
            builder.Ignore(p => p.RecurringCyclePeriod);
            builder.Ignore(p => p.RentalPricePeriod);

            //builder.HasMany(p => p.ProductTags)
            //    .WithMany(pt => pt.Products)
            //    .Map(m => m.ToTable("Product_ProductTag_Mapping"));
            builder.Ignore(i => i.ProductTags);//Pekmez
            builder.Ignore(i => i.AppliedDiscounts);//Pekmez
        }
    }
}