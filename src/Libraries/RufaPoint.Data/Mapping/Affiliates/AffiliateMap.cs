using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RufaPoint.Core.Domain.Affiliates;
using RufaPoint.Core.Domain.Common;

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
           /* this.ToTable("Affiliate");
            this.HasKey(a => a.Id);

            this.HasRequired(a => a.Address).WithMany().HasForeignKey(x => x.AddressId).WillCascadeOnDelete(false);*/
        }
        protected override void DoConfig(EntityTypeBuilder<Affiliate> builder)
        {
            builder.ToTable("Affiliate").HasKey(a => a.Id);
            builder.HasOne<Address>(a => a.Address).WithMany().HasForeignKey(x => x.AddressId).OnDelete(DeleteBehavior.ClientSetNull);
            //builder.HasRequired(a => a.Address).WithMany().HasForeignKey(x => x.AddressId).WillCascadeOnDelete(false);
        }
    }
}