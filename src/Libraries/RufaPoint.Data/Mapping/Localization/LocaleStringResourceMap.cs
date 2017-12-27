using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RufaPoint.Core.Domain.Localization;

namespace RufaPoint.Data.Mapping.Localization
{
    /// <summary>
    /// Mapping class
    /// </summary>
    public partial class LocaleStringResourceMap : NopEntityTypeConfiguration<LocaleStringResource>
    {
        /// <summary>
        /// Ctor
        /// </summary>
        public LocaleStringResourceMap()
        {
            //this.ToTable("LocaleStringResource");
            //this.HasKey(lsr => lsr.Id);
            //this.Property(lsr => lsr.ResourceName).IsRequired().HasMaxLength(200);
            //this.Property(lsr => lsr.ResourceValue).IsRequired();

            //this.HasRequired(lsr => lsr.Language)
            //    .WithMany()
            //    .HasForeignKey(lsr => lsr.LanguageId);
        }
        protected override void DoConfig(EntityTypeBuilder<LocaleStringResource> builder)
        {
            builder.ToTable("LocaleStringResource").HasKey(lsr => lsr.Id);
            builder.Property(lsr => lsr.ResourceName).IsRequired().HasMaxLength(200);
            builder.Property(lsr => lsr.ResourceValue).IsRequired();

            builder.HasOne(lsr => lsr.Language)
                .WithMany()
                .HasForeignKey(lsr => lsr.LanguageId);
        }
    }
}