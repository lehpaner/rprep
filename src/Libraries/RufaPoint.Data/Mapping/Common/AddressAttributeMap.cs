using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RufaPoint.Core.Domain.Common;

namespace RufaPoint.Data.Mapping.Common
{
    /// <summary>
    /// Mapping class
    /// </summary>
    public partial class AddressAttributeMap : NopEntityTypeConfiguration<AddressAttribute>
    {
        /// <summary>
        /// Ctor
        /// </summary>
        public AddressAttributeMap()
        {
            //this.ToTable("AddressAttribute");
            //this.HasKey(aa => aa.Id);
            //this.Property(aa => aa.Name).IsRequired().HasMaxLength(400);

            //this.Ignore(aa => aa.AttributeControlType);
        }
        protected override void DoConfig(EntityTypeBuilder<AddressAttribute> builder)
        {
            builder.ToTable("AddressAttribute").HasKey(aa => aa.Id);
            builder.Property(aa => aa.Name).IsRequired().HasMaxLength(400);

            builder.Ignore(aa => aa.AttributeControlType);
        }
    }
}