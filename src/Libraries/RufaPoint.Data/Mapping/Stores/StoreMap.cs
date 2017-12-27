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
            this.ToTable("Store");
            this.HasKey(s => s.Id);
            this.Property(s => s.Name).IsRequired().HasMaxLength(400);
            this.Property(s => s.Url).IsRequired().HasMaxLength(400);
            this.Property(s => s.SecureUrl).HasMaxLength(400);
            this.Property(s => s.Hosts).HasMaxLength(1000);

            this.Property(s => s.CompanyName).HasMaxLength(1000);
            this.Property(s => s.CompanyAddress).HasMaxLength(1000);
            this.Property(s => s.CompanyPhoneNumber).HasMaxLength(1000);
            this.Property(s => s.CompanyVat).HasMaxLength(1000);
        }
    }
}