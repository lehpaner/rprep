using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RufaPoint.Core.Domain.Common;

namespace RufaPoint.Data.Mapping.Common
{
    /// <summary>
    /// Mapping class
    /// </summary>
    public partial class GenericAttributeMap : NopEntityTypeConfiguration<GenericAttribute>
    {
        /// <summary>
        /// Ctor
        /// </summary>
        public GenericAttributeMap()
        {
            //this.ToTable("GenericAttribute");
            //this.HasKey(ga => ga.Id);

            //this.Property(ga => ga.KeyGroup).IsRequired().HasMaxLength(400);
            //this.Property(ga => ga.Key).IsRequired().HasMaxLength(400);
            //this.Property(ga => ga.Value).IsRequired();
        }
        protected override void DoConfig(EntityTypeBuilder<GenericAttribute> builder)
        {
            builder.ToTable("GenericAttribute").HasKey(ga => ga.Id);

            builder.Property(ga => ga.KeyGroup).IsRequired().HasMaxLength(400);
            builder.Property(ga => ga.Key).IsRequired().HasMaxLength(400);
            builder.Property(ga => ga.Value).IsRequired();
        }
    }
}