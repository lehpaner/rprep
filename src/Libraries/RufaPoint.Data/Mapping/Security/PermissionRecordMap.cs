using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RufaPoint.Core.Domain.Security;

namespace RufaPoint.Data.Mapping.Security
{
    /// <summary>
    /// Mapping class
    /// </summary>
    public partial class PermissionRecordMap : NopEntityTypeConfiguration<PermissionRecord>
    {
        /// <summary>
        /// Ctor
        /// </summary>
        public PermissionRecordMap()
        {
            //this.ToTable("PermissionRecord");
            //this.HasKey(pr => pr.Id);
            //this.Property(pr => pr.Name).IsRequired();
            //this.Property(pr => pr.SystemName).IsRequired().HasMaxLength(255);
            //this.Property(pr => pr.Category).IsRequired().HasMaxLength(255);

            //this.HasMany(pr => pr.CustomerRoles)
            //    .WithMany(cr => cr.PermissionRecords)
            //    .Map(m => m.ToTable("PermissionRecord_Role_Mapping"));
        }
        protected override void DoConfig(EntityTypeBuilder<PermissionRecord> builder)
        {
            builder.ToTable("PermissionRecord").HasKey(pr => pr.Id);
            builder.Property(pr => pr.Name).IsRequired();
            builder.Property(pr => pr.SystemName).IsRequired().HasMaxLength(255);
            builder.Property(pr => pr.Category).IsRequired().HasMaxLength(255);

            //builder.HasMany(pr => pr.CustomerRoles);
               // .WithMany(cr => cr.PermissionRecords)
               // .Map(m => m.ToTable("PermissionRecord_Role_Mapping"));
        }
    }
}