using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RufaPoint.Core.Domain.Orders;

namespace RufaPoint.Data.Mapping.Orders
{
    /// <summary>
    /// Mapping class
    /// </summary>
    public partial class CheckoutAttributeMap : NopEntityTypeConfiguration<CheckoutAttribute>
    {
        /// <summary>
        /// Ctor
        /// </summary>
        public CheckoutAttributeMap()
        {
            //this.ToTable("CheckoutAttribute");
            //this.HasKey(ca => ca.Id);
            //this.Property(ca => ca.Name).IsRequired().HasMaxLength(400);

            //this.Ignore(ca => ca.AttributeControlType);
        }
        protected override void DoConfig(EntityTypeBuilder<CheckoutAttribute> builder)
        {
            builder.ToTable("CheckoutAttribute").HasKey(ca => ca.Id);
            builder.Property(ca => ca.Name).IsRequired().HasMaxLength(400);

            builder.Ignore(ca => ca.AttributeControlType);
        }
    }
}