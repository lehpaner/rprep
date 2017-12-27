using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RufaPoint.Core.Domain.Catalog;

namespace RufaPoint.Data.Mapping.Catalog
{
    /// <summary>
    /// Mapping class
    /// </summary>
    public partial class SpecificationAttributeMap : NopEntityTypeConfiguration<SpecificationAttribute>
    {
        /// <summary>
        /// Ctor
        /// </summary>
        public SpecificationAttributeMap()
        {
            //this.ToTable("SpecificationAttribute");
            //this.HasKey(sa => sa.Id);
            //this.Property(sa => sa.Name).IsRequired();
        }
        protected override void DoConfig(EntityTypeBuilder<SpecificationAttribute> builder)
        {
            builder.ToTable("SpecificationAttribute").HasKey(sa => sa.Id);
            builder.Property(sa => sa.Name).IsRequired();
        }
    }
}