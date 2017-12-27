using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RufaPoint.Core.Domain.Directory;

namespace RufaPoint.Data.Mapping.Directory
{
    /// <summary>
    /// Mapping class
    /// </summary>
    public partial class CountryMap : NopEntityTypeConfiguration<Country>
    {
        /// <summary>
        /// Ctor
        /// </summary>
        public CountryMap()
        {
            //this.ToTable("Country");
            //this.HasKey(c => c.Id);
            //this.Property(c => c.Name).IsRequired().HasMaxLength(100);
            //this.Property(c => c.TwoLetterIsoCode).HasMaxLength(2);
            //this.Property(c => c.ThreeLetterIsoCode).HasMaxLength(3);
        }
        protected override void DoConfig(EntityTypeBuilder<Country> builder)
        {
            builder.ToTable("Country").HasKey(c => c.Id);
            builder.Property(c => c.Name).IsRequired().HasMaxLength(100);
            builder.Property(c => c.TwoLetterIsoCode).HasMaxLength(2);
            builder.Property(c => c.ThreeLetterIsoCode).HasMaxLength(3);
            builder.Ignore(i => i.RestrictedShippingMethods);//Pekmez
        }
    }
}