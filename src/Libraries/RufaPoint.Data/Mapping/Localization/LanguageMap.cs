using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RufaPoint.Core.Domain.Localization;

namespace RufaPoint.Data.Mapping.Localization
{
    /// <summary>
    /// Mapping class
    /// </summary>
    public partial class LanguageMap : NopEntityTypeConfiguration<Language>
    {
        /// <summary>
        /// Ctor
        /// </summary>
        public LanguageMap()
        {
            //this.ToTable("Language");
            //this.HasKey(l => l.Id);
            //this.Property(l => l.Name).IsRequired().HasMaxLength(100);
            //this.Property(l => l.LanguageCulture).IsRequired().HasMaxLength(20);
            //this.Property(l => l.UniqueSeoCode).HasMaxLength(2);
            //this.Property(l => l.FlagImageFileName).HasMaxLength(50);
        }
        protected override void DoConfig(EntityTypeBuilder<Language> builder)
        {
            builder.ToTable("Language").HasKey(l => l.Id);
            builder.Property(l => l.Name).IsRequired().HasMaxLength(100);
            builder.Property(l => l.LanguageCulture).IsRequired().HasMaxLength(20);
            builder.Property(l => l.UniqueSeoCode).HasMaxLength(2);
            builder.Property(l => l.FlagImageFileName).HasMaxLength(50);
        }
    }
}