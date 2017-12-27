using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RufaPoint.Core.Domain.Orders;

namespace RufaPoint.Data.Mapping.Orders
{
    /// <summary>
    /// Mapping class
    /// </summary>
    public partial class CheckoutAttributeValueMap : NopEntityTypeConfiguration<CheckoutAttributeValue>
    {
        /// <summary>
        /// Ctor
        /// </summary>
        public CheckoutAttributeValueMap()
        {
            //this.ToTable("CheckoutAttributeValue");
            //this.HasKey(cav => cav.Id);
            //this.Property(cav => cav.Name).IsRequired().HasMaxLength(400);
            //this.Property(cav => cav.ColorSquaresRgb).HasMaxLength(100);
            //this.Property(cav => cav.PriceAdjustment).HasPrecision(18, 4);
            //this.Property(cav => cav.WeightAdjustment).HasPrecision(18, 4);

            //this.HasRequired(cav => cav.CheckoutAttribute)
            //    .WithMany(ca => ca.CheckoutAttributeValues)
            //    .HasForeignKey(cav => cav.CheckoutAttributeId);
        }
        protected override void DoConfig(EntityTypeBuilder<CheckoutAttributeValue> builder)
        {
            builder.ToTable("CheckoutAttributeValue").HasKey(cav => cav.Id);
            builder.Property(cav => cav.Name).IsRequired().HasMaxLength(400);
            builder.Property(cav => cav.ColorSquaresRgb).HasMaxLength(100);
            //builder.Property(cav => cav.PriceAdjustment).HasPrecision(18, 4);
            //builder.Property(cav => cav.WeightAdjustment).HasPrecision(18, 4);

            builder.HasOne(cav => cav.CheckoutAttribute)
                .WithMany(ca => ca.CheckoutAttributeValues)
                .HasForeignKey(cav => cav.CheckoutAttributeId);
        }
    }
}