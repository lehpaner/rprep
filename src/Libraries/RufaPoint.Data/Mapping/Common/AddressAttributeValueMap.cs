using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RufaPoint.Core.Domain.Common;

namespace RufaPoint.Data.Mapping.Common
{
    /// <summary>
    /// Mapping class
    /// </summary>
    public partial class AddressAttributeValueMap : NopEntityTypeConfiguration<AddressAttributeValue>
    {
        /// <summary>
        /// Ctor
        /// </summary>
        public AddressAttributeValueMap()
        {
            //this.ToTable("AddressAttributeValue");
            //this.HasKey(aav => aav.Id);
            //this.Property(aav => aav.Name).IsRequired().HasMaxLength(400);

            //this.HasRequired(aav => aav.AddressAttribute)
            //    .WithMany(aa => aa.AddressAttributeValues)
            //    .HasForeignKey(aav => aav.AddressAttributeId);
        }
        protected override void DoConfig(EntityTypeBuilder<AddressAttributeValue> builder)
        {
            builder.ToTable("AddressAttributeValue").HasKey(aav => aav.Id);
            builder.Property(aav => aav.Name).IsRequired().HasMaxLength(400);

            builder.HasOne(aav => aav.AddressAttribute)
                .WithMany(aa => aa.AddressAttributeValues)
                .HasForeignKey(aav => aav.AddressAttributeId);
        }
    }
}