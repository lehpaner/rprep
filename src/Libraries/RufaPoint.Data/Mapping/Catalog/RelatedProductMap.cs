using RufaPoint.Core.Domain.Catalog;

namespace RufaPoint.Data.Mapping.Catalog
{
    /// <summary>
    /// Mapping class
    /// </summary>
    public partial class RelatedProductMap : NopEntityTypeConfiguration<RelatedProduct>
    {
        /// <summary>
        /// Ctor
        /// </summary>
        public RelatedProductMap()
        {
            this.ToTable("RelatedProduct");
            this.HasKey(c => c.Id);
        }
    }
}