using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RufaPoint.Core.Domain.Localization;

namespace RufaPoint.Data.Mapping.Localization
{
    /// <summary>
    /// Mapping class
    /// </summary>
    public partial class LocalizedPropertyMap : NopEntityTypeConfiguration<LocalizedProperty>
    {
        /// <summary>
        /// Ctor
        /// </summary>
        public LocalizedPropertyMap()
        {
            //this.ToTable("LocalizedProperty");
            //this.HasKey(lp => lp.Id);

            //this.Property(lp => lp.LocaleKeyGroup).IsRequired().HasMaxLength(400);
            //this.Property(lp => lp.LocaleKey).IsRequired().HasMaxLength(400);
            //this.Property(lp => lp.LocaleValue).IsRequired();

            //this.HasRequired(lp => lp.Language)
            //    .WithMany()
            //    .HasForeignKey(lp => lp.LanguageId);
        }
        protected override void DoConfig(EntityTypeBuilder<LocalizedProperty> builder)
        {
            builder.ToTable("LocalizedProperty").HasKey(lp => lp.Id);

            builder.Property(lp => lp.LocaleKeyGroup).IsRequired().HasMaxLength(400);
            builder.Property(lp => lp.LocaleKey).IsRequired().HasMaxLength(400);
            builder.Property(lp => lp.LocaleValue).IsRequired();

            builder.HasOne(lp => lp.Language)
                .WithMany()
                .HasForeignKey(lp => lp.LanguageId);
        }
    }
}