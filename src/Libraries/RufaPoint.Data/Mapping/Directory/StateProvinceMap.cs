using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RufaPoint.Core.Domain.Directory;

namespace RufaPoint.Data.Mapping.Directory
{
    /// <summary>
    /// Mapping class
    /// </summary>
    public partial class StateProvinceMap : NopEntityTypeConfiguration<StateProvince>
    {
        /// <summary>
        /// Ctor
        /// </summary>
        public StateProvinceMap()
        {
            //this.ToTable("StateProvince");
            //this.HasKey(sp => sp.Id);
            //this.Property(sp => sp.Name).IsRequired().HasMaxLength(100);
            //this.Property(sp => sp.Abbreviation).HasMaxLength(100);

            //this.HasRequired(sp => sp.Country)
            //    .WithMany(c => c.StateProvinces)
            //    .HasForeignKey(sp => sp.CountryId);
        }
        protected override void DoConfig(EntityTypeBuilder<StateProvince> builder)
        {
            builder.ToTable("StateProvince").HasKey(sp => sp.Id);
            builder.Property(sp => sp.Name).IsRequired().HasMaxLength(100);
            builder.Property(sp => sp.Abbreviation).HasMaxLength(100);

            builder.HasOne(sp => sp.Country)
                .WithMany(c => c.StateProvinces)
                .HasForeignKey(sp => sp.CountryId);
        }
    }
}