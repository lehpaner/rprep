using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RufaPoint.Core.Domain.Media;

namespace RufaPoint.Data.Mapping.Media
{
    /// <summary>
    /// Mapping class
    /// </summary>
    public partial class DownloadMap : NopEntityTypeConfiguration<Download>
    {
        /// <summary>
        /// Ctor
        /// </summary>
        public DownloadMap()
        {
            //this.ToTable("Download");
            //this.HasKey(p => p.Id);
            //this.Property(p => p.DownloadBinary).IsMaxLength();
        }
        protected override void DoConfig(EntityTypeBuilder<Download> builder)
        {
            builder.ToTable("Download").HasKey(p => p.Id);
            //builder.Property(p => p.DownloadBinary).IsMaxLength();
        }
    }
}