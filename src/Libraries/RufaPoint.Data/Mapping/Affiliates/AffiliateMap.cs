using RufaPoint.Core.Domain.Affiliates;

namespace RufaPoint.Data.Mapping.Affiliates
{
    /// <summary>
    /// Mapping class
    /// </summary>
    public partial class AffiliateMap : NopEntityTypeConfiguration<Affiliate>
    {
        /// <summary>
        /// Ctor
        /// </summary>
        public AffiliateMap()
        {
            this.ToTable("Affiliate");
            this.HasKey(a => a.Id);

            this.HasRequired(a => a.Address).WithMany().HasForeignKey(x => x.AddressId).WillCascadeOnDelete(false);
        }
    }
}