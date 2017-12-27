using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RufaPoint.Core.Domain.Catalog;

namespace RufaPoint.Data.Mapping.Catalog
{
    /// <summary>
    /// Mapping class
    /// </summary>
    public partial class StockQuantityHistoryMap : NopEntityTypeConfiguration<StockQuantityHistory>
    {
        /// <summary>
        /// Ctor
        /// </summary>
        public StockQuantityHistoryMap()
        {
            //this.ToTable("StockQuantityHistory");
            //this.HasKey(historyEntry => historyEntry.Id);

            //this.HasRequired(historyEntry => historyEntry.Product)
            //    .WithMany()
            //    .HasForeignKey(historyEntry => historyEntry.ProductId)
            //    .WillCascadeOnDelete(true);
        }
        protected override void DoConfig(EntityTypeBuilder<StockQuantityHistory> builder)
        {
            builder.ToTable("StockQuantityHistory").HasKey(historyEntry => historyEntry.Id);

            builder.HasOne(historyEntry => historyEntry.Product)
                .WithMany()
                .HasForeignKey(historyEntry => historyEntry.ProductId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}