using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RufaPoint.Core.Domain.Vendors;

namespace RufaPoint.Data.Mapping.Vendors
{
    /// <summary>
    /// Mapping class
    /// </summary>
    public partial class VendorNoteMap : NopEntityTypeConfiguration<VendorNote>
    {
        /// <summary>
        /// Ctor
        /// </summary>
        public VendorNoteMap()
        {
            //this.ToTable("VendorNote");
            //this.HasKey(vn => vn.Id);
            //this.Property(vn => vn.Note).IsRequired();

            //this.HasRequired(vn => vn.Vendor)
            //    .WithMany(v => v.VendorNotes)
            //    .HasForeignKey(vn => vn.VendorId);
        }
        protected override void DoConfig(EntityTypeBuilder<VendorNote> builder)
        {
            builder.ToTable("VendorNote").HasKey(vn => vn.Id);
            builder.Property(vn => vn.Note).IsRequired();

            builder.HasOne(vn => vn.Vendor)
                .WithMany(v => v.VendorNotes)
                .HasForeignKey(vn => vn.VendorId);
        }
    }
}