using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RufaPoint.Core.Domain.Common;

namespace RufaPoint.Data.Mapping.Common
{
    /// <summary>
    /// Mapping class
    /// </summary>
    public partial class AddressMap : NopEntityTypeConfiguration<Address>
    {
        /// <summary>
        /// Ctor
        /// </summary>
        public AddressMap()
        {
            //this.ToTable("Address");
            //this.HasKey(a => a.Id);

            //this.HasOptional(a => a.Country)
            //    .WithMany()
            //    .HasForeignKey(a => a.CountryId).WillCascadeOnDelete(false);

            //this.HasOptional(a => a.StateProvince)
            //    .WithMany()
            //    .HasForeignKey(a => a.StateProvinceId).WillCascadeOnDelete(false);
        }
        protected override void DoConfig(EntityTypeBuilder<Address> builder)
        {
            builder.ToTable("Address").HasKey(a => a.Id);
            builder.HasOne(a => a.Country).WithMany().HasForeignKey(a => a.CountryId).OnDelete(DeleteBehavior.ClientSetNull);
            //builder.HasOptional(a => a.Country)
            //    .WithMany()
            //    .HasForeignKey(a => a.CountryId).WillCascadeOnDelete(false);

            //builder.HasOptional(a => a.StateProvince)
            //    .WithMany()
            //    .HasForeignKey(a => a.StateProvinceId).WillCascadeOnDelete(false);
        }
    }
}
