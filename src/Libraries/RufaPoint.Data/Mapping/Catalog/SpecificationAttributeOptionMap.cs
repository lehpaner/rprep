using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RufaPoint.Core.Domain.Catalog;

namespace RufaPoint.Data.Mapping.Catalog
{
    /// <summary>
    /// Mapping class
    /// </summary>
    public partial class SpecificationAttributeOptionMap : NopEntityTypeConfiguration<SpecificationAttributeOption>
    {
        /// <summary>
        /// Ctor
        /// </summary>
        public SpecificationAttributeOptionMap()
        {
            //this.ToTable("SpecificationAttributeOption");
            //this.HasKey(sao => sao.Id);
            //this.Property(sao => sao.Name).IsRequired();
            //this.Property(sao => sao.ColorSquaresRgb).HasMaxLength(100);

            //this.HasRequired(sao => sao.SpecificationAttribute)
            //    .WithMany(sa => sa.SpecificationAttributeOptions)
            //    .HasForeignKey(sao => sao.SpecificationAttributeId);
        }
        protected override void DoConfig(EntityTypeBuilder<SpecificationAttributeOption> builder)
        {
            builder.ToTable("SpecificationAttributeOption").HasKey(sao => sao.Id);
            builder.Property(sao => sao.Name).IsRequired();
            builder.Property(sao => sao.ColorSquaresRgb).HasMaxLength(100);

            builder.HasOne(sao => sao.SpecificationAttribute)
                .WithMany(sa => sa.SpecificationAttributeOptions)
                .HasForeignKey(sao => sao.SpecificationAttributeId);
        }
    }
}