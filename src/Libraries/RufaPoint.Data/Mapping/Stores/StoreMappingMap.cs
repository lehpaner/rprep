using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RufaPoint.Core.Domain.Stores;

namespace RufaPoint.Data.Mapping.Stores
{
    /// <summary>
    /// Mapping class
    /// </summary>
    public partial class StoreMappingMap : NopEntityTypeConfiguration<StoreMapping>
    {
        /// <summary>
        /// Ctor
        /// </summary>
        public StoreMappingMap()
        {
            //this.ToTable("StoreMapping");
            //this.HasKey(sm => sm.Id);

            //this.Property(sm => sm.EntityName).IsRequired().HasMaxLength(400);

            //this.HasRequired(sm => sm.Store)
            //    .WithMany()
            //    .HasForeignKey(sm => sm.StoreId)
            //    .WillCascadeOnDelete(true);
        }
        protected override void DoConfig(EntityTypeBuilder<StoreMapping> builder)
        {
            builder.ToTable("StoreMapping").HasKey(sm => sm.Id);

            builder.Property(sm => sm.EntityName).IsRequired().HasMaxLength(400);

            builder.HasOne(sm => sm.Store)
                .WithMany()
                .HasForeignKey(sm => sm.StoreId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}