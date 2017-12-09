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
            this.ToTable("StockQuantityHistory");
            this.HasKey(historyEntry => historyEntry.Id);

            this.HasRequired(historyEntry => historyEntry.Product)
                .WithMany()
                .HasForeignKey(historyEntry => historyEntry.ProductId)
                .WillCascadeOnDelete(true);
        }
    }
}