using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RufaPoint.Core.Domain.Vendors;

namespace RufaPoint.Data.Mapping.Vendors
{
    /// <summary>
    /// Mapping class
    /// </summary>
    public partial class VendorMap : NopEntityTypeConfiguration<Vendor>
    {
        /// <summary>
        /// Ctor
        /// </summary>
        public VendorMap()
        {
           /* this.ToTable("Vendor");
            this.HasKey(v => v.Id);

            this.Property(v => v.Name).IsRequired().HasMaxLength(400);
            this.Property(v => v.Email).HasMaxLength(400);
            this.Property(v => v.MetaKeywords).HasMaxLength(400);
            this.Property(v => v.MetaTitle).HasMaxLength(400);
            this.Property(v => v.PageSizeOptions).HasMaxLength(200);*/
        }
        protected override void DoConfig(EntityTypeBuilder<Vendor> builder)
        {
            builder.ToTable("Vendor").HasKey(a => a.Id);
            builder.Property(p => p.Name).IsRequired().HasMaxLength(400);
            builder.Property(v => v.Email).HasMaxLength(400);
            builder.Property(v => v.MetaKeywords).HasMaxLength(400);
            builder.Property(v => v.MetaTitle).HasMaxLength(400);
            builder.Property(v => v.PageSizeOptions).HasMaxLength(200);

        }
    }
}