using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RufaPoint.Core.Domain.Stores;

namespace RufaPoint.Data.Mapping.Stores
{
    /// <summary>
    /// Mapping class
    /// </summary>
    public partial class StoreMap : NopEntityTypeConfiguration<Store>
    {
        /// <summary>
        /// Ctor
        /// </summary>
        public StoreMap()
        {
            //this.ToTable("Store");
            //this.HasKey(s => s.Id);
            //this.Property(s => s.Name).IsRequired().HasMaxLength(400);
            //this.Property(s => s.Url).IsRequired().HasMaxLength(400);
            //this.Property(s => s.SecureUrl).HasMaxLength(400);
            //this.Property(s => s.Hosts).HasMaxLength(1000);

            //this.Property(s => s.CompanyName).HasMaxLength(1000);
            //this.Property(s => s.CompanyAddress).HasMaxLength(1000);
            //this.Property(s => s.CompanyPhoneNumber).HasMaxLength(1000);
            //this.Property(s => s.CompanyVat).HasMaxLength(1000);
        }
        protected override void DoConfig(EntityTypeBuilder<Store> builder)
        {
            builder.ToTable("Store").HasKey(s => s.Id);
            builder.Property(s => s.Name).IsRequired().HasMaxLength(400);
            builder.Property(s => s.Url).IsRequired().HasMaxLength(400);
            builder.Property(s => s.SecureUrl).HasMaxLength(400);
            builder.Property(s => s.Hosts).HasMaxLength(1000);

            builder.Property(s => s.CompanyName).HasMaxLength(1000);
            builder.Property(s => s.CompanyAddress).HasMaxLength(1000);
            builder.Property(s => s.CompanyPhoneNumber).HasMaxLength(1000);
            builder.Property(s => s.CompanyVat).HasMaxLength(1000);
        }
    }
}