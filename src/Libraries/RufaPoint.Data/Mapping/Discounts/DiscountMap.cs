using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RufaPoint.Core.Domain.Discounts;

namespace RufaPoint.Data.Mapping.Discounts
{
    /// <summary>
    /// Mapping class
    /// </summary>
    public partial class DiscountMap : NopEntityTypeConfiguration<Discount>
    {
        /// <summary>
        /// Ctor
        /// </summary>
        public DiscountMap()
        {
            //this.ToTable("Discount");
            //this.HasKey(d => d.Id);
            //this.Property(d => d.Name).IsRequired().HasMaxLength(200);
            //this.Property(d => d.CouponCode).HasMaxLength(100);
            //this.Property(d => d.DiscountPercentage).HasPrecision(18, 4);
            //this.Property(d => d.DiscountAmount).HasPrecision(18, 4);
            //this.Property(d => d.MaximumDiscountAmount).HasPrecision(18, 4);

            //this.Ignore(d => d.DiscountType);
            //this.Ignore(d => d.DiscountLimitation);

            //this.HasMany(dr => dr.DiscountRequirements)
            //    .WithRequired(d => d.Discount)
            //    .HasForeignKey(dr => dr.DiscountId);

            //this.HasMany(dr => dr.AppliedToCategories)
            //    .WithMany(c => c.AppliedDiscounts)
            //    .Map(m => m.ToTable("Discount_AppliedToCategories"));

            //this.HasMany(dr => dr.AppliedToManufacturers)
            //    .WithMany(c => c.AppliedDiscounts)
            //    .Map(m => m.ToTable("Discount_AppliedToManufacturers"));

            //this.HasMany(dr => dr.AppliedToProducts)
            //    .WithMany(p => p.AppliedDiscounts)
            //    .Map(m => m.ToTable("Discount_AppliedToProducts"));
        }
        protected override void DoConfig(EntityTypeBuilder<Discount> builder)
        {
            builder.ToTable("Discount").HasKey(d => d.Id);
            builder.Property(d => d.Name).IsRequired().HasMaxLength(200);
            builder.Property(d => d.CouponCode).HasMaxLength(100);
            //builder.Property(d => d.DiscountPercentage).HasPrecision(18, 4);
            //builder.Property(d => d.DiscountAmount).HasPrecision(18, 4);
            //builder.Property(d => d.MaximumDiscountAmount).HasPrecision(18, 4);

            builder.Ignore(d => d.DiscountType);
            builder.Ignore(d => d.DiscountLimitation);
            builder.Ignore(d => d.AppliedToCategories); //Pekmez

            //builder.HasMany(dr => dr.DiscountRequirements)
            //    .WithRequired(d => d.Discount)
            //    .HasForeignKey(dr => dr.DiscountId);

            //builder.HasMany(dr => dr.AppliedToCategories)
            //    .WithMany(c => c.AppliedDiscounts)
            //    .Map(m => m.ToTable("Discount_AppliedToCategories"));

            //builder.HasMany(dr => dr.AppliedToManufacturers)
            //    .WithMany(c => c.AppliedDiscounts)
            //    .Map(m => m.ToTable("Discount_AppliedToManufacturers"));

            //builder.HasMany(dr => dr.AppliedToProducts)
            //    .WithMany(p => p.AppliedDiscounts)
            //    .Map(m => m.ToTable("Discount_AppliedToProducts"));
        }
    }
}