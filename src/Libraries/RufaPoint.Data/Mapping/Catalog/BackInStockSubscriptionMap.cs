using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RufaPoint.Core.Domain.Catalog;

namespace RufaPoint.Data.Mapping.Catalog
{
    /// <summary>
    /// Mapping class
    /// </summary>
    public partial class BackInStockSubscriptionMap : NopEntityTypeConfiguration<BackInStockSubscription>
    {
        /// <summary>
        /// Ctor
        /// </summary>
        public BackInStockSubscriptionMap()
        {
            /*       this.ToTable("BackInStockSubscription");
                   this.HasKey(x => x.Id);

                   this.HasRequired(x => x.Product)
                       .WithMany()
                       .HasForeignKey(x => x.ProductId)
                       .WillCascadeOnDelete(true);

                   this.HasRequired(x => x.Customer)
                       .WithMany()
                       .HasForeignKey(x => x.CustomerId)
                       .WillCascadeOnDelete(true);*/
        }
        protected override void DoConfig(EntityTypeBuilder<BackInStockSubscription> builder)
        {
            builder.ToTable("BackInStockSubscription").HasKey(x => x.Id);
        }
    }
}