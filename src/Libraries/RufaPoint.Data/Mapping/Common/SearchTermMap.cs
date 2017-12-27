using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RufaPoint.Core.Domain.Common;

namespace RufaPoint.Data.Mapping.Common
{
    /// <summary>
    /// Mapping class
    /// </summary>
    public partial class SearchTermMap : NopEntityTypeConfiguration<SearchTerm>
    {
        /// <summary>
        /// Ctor
        /// </summary>
        public SearchTermMap()
        {
            //this.ToTable("SearchTerm");
            //this.HasKey(st => st.Id);
        }
        protected override void DoConfig(EntityTypeBuilder<SearchTerm> builder)
        {
            builder.ToTable("SearchTerm").HasKey(st => st.Id);
        }
    }
}
