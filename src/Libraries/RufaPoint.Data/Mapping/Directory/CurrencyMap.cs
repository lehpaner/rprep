using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RufaPoint.Core.Domain.Directory;

namespace RufaPoint.Data.Mapping.Directory
{
    /// <summary>
    /// Mapping class
    /// </summary>
    public partial class CurrencyMap : NopEntityTypeConfiguration<Currency>
    {
        /// <summary>
        /// Ctor
        /// </summary>
        public CurrencyMap()
        {
            //this.ToTable("Currency");
            //this.HasKey(c => c.Id);
            //this.Property(c => c.Name).IsRequired().HasMaxLength(50);
            //this.Property(c => c.CurrencyCode).IsRequired().HasMaxLength(5);
            //this.Property(c => c.DisplayLocale).HasMaxLength(50);
            //this.Property(c => c.CustomFormatting).HasMaxLength(50);
            //this.Property(c => c.Rate).HasPrecision(18, 4);

            //this.Ignore(c => c.RoundingType);
        }
        protected override void DoConfig(EntityTypeBuilder<Currency> builder)
        {
            builder.ToTable("Currency").HasKey(c => c.Id);
            builder.Property(c => c.Name).IsRequired().HasMaxLength(50);
            builder.Property(c => c.CurrencyCode).IsRequired().HasMaxLength(5);
            builder.Property(c => c.DisplayLocale).HasMaxLength(50);
            builder.Property(c => c.CustomFormatting).HasMaxLength(50);
            //builder.Property(c => c.Rate).HasPrecision(18, 4);

            builder.Ignore(c => c.RoundingType);
        }
    }
}