using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RufaPoint.Core.Domain.Seo;

namespace RufaPoint.Data.Mapping.Seo
{
    /// <summary>
    /// Mapping class
    /// </summary>
    public partial class UrlRecordMap : NopEntityTypeConfiguration<UrlRecord>
    {
        /// <summary>
        /// Ctor
        /// </summary>
        public UrlRecordMap()
        {
            //this.ToTable("UrlRecord");
            //this.HasKey(lp => lp.Id);

            //this.Property(lp => lp.EntityName).IsRequired().HasMaxLength(400);
            //this.Property(lp => lp.Slug).IsRequired().HasMaxLength(400);
        }
        protected override void DoConfig(EntityTypeBuilder<UrlRecord> builder)
        {
            builder.ToTable("UrlRecord").HasKey(lp => lp.Id);

            builder.Property(lp => lp.EntityName).IsRequired().HasMaxLength(400);
            builder.Property(lp => lp.Slug).IsRequired().HasMaxLength(400);
        }
    }
}