using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RufaPoint.Core.Domain.Media;

namespace RufaPoint.Data.Mapping.Media
{
    /// <summary>
    /// Mapping class
    /// </summary>
    public partial class PictureMap : NopEntityTypeConfiguration<Picture>
    {
        /// <summary>
        /// Ctor
        /// </summary>
        public PictureMap()
        {
            //this.ToTable("Picture");
            //this.HasKey(p => p.Id);
            //this.Property(p => p.PictureBinary).IsMaxLength();
            //this.Property(p => p.MimeType).IsRequired().HasMaxLength(40);
            //this.Property(p => p.SeoFilename).HasMaxLength(300);
        }
        protected override void DoConfig(EntityTypeBuilder<Picture> builder)
        {
            builder.ToTable("Picture").HasKey(p => p.Id);
         //   builder.Property(p => p.PictureBinary).IsMaxLength();
            builder.Property(p => p.MimeType).IsRequired().HasMaxLength(40);
            builder.Property(p => p.SeoFilename).HasMaxLength(300);
        }
    }
}