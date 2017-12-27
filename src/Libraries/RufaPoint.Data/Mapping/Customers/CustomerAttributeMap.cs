using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RufaPoint.Core.Domain.Customers;

namespace RufaPoint.Data.Mapping.Customers
{
    /// <summary>
    /// Mapping class
    /// </summary>
    public partial class CustomerAttributeMap : NopEntityTypeConfiguration<CustomerAttribute>
    {
        /// <summary>
        /// Ctor
        /// </summary>
        public CustomerAttributeMap()
        {
            //this.ToTable("CustomerAttribute");
            //this.HasKey(ca => ca.Id);
            //this.Property(ca => ca.Name).IsRequired().HasMaxLength(400);

            //this.Ignore(ca => ca.AttributeControlType);
        }
        protected override void DoConfig(EntityTypeBuilder<CustomerAttribute> builder)
        {
            builder.ToTable("CustomerAttribute").HasKey(ca => ca.Id);
            builder.Property(ca => ca.Name).IsRequired().HasMaxLength(400);

            builder.Ignore(ca => ca.AttributeControlType);
        }
    }
}