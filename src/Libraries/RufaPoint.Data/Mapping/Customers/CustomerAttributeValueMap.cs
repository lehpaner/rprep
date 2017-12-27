using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RufaPoint.Core.Domain.Customers;

namespace RufaPoint.Data.Mapping.Customers
{
    /// <summary>
    /// Mapping class
    /// </summary>
    public partial class CustomerAttributeValueMap : NopEntityTypeConfiguration<CustomerAttributeValue>
    {
        /// <summary>
        /// Ctor
        /// </summary>
        public CustomerAttributeValueMap()
        {
            //this.ToTable("CustomerAttributeValue");
            //this.HasKey(cav => cav.Id);
            //this.Property(cav => cav.Name).IsRequired().HasMaxLength(400);

            //this.HasRequired(cav => cav.CustomerAttribute)
            //    .WithMany(ca => ca.CustomerAttributeValues)
            //    .HasForeignKey(cav => cav.CustomerAttributeId);
        }
        protected override void DoConfig(EntityTypeBuilder<CustomerAttributeValue> builder)
        {
            builder.ToTable("CustomerAttributeValue").HasKey(cav => cav.Id);
            builder.Property(cav => cav.Name).IsRequired().HasMaxLength(400);

            builder.HasOne(cav => cav.CustomerAttribute)
                .WithMany(ca => ca.CustomerAttributeValues)
                .HasForeignKey(cav => cav.CustomerAttributeId);
        }
    }
}