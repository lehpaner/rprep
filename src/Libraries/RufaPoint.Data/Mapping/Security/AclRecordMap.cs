using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RufaPoint.Core.Domain.Security;

namespace RufaPoint.Data.Mapping.Security
{
    /// <summary>
    /// Mapping class
    /// </summary>
    public partial class AclRecordMap : NopEntityTypeConfiguration<AclRecord>
    {
        /// <summary>
        /// Ctor
        /// </summary>
        public AclRecordMap()
        {
            //this.ToTable("AclRecord");
            //this.HasKey(ar => ar.Id);

            //this.Property(ar => ar.EntityName).IsRequired().HasMaxLength(400);

            //this.HasRequired(ar => ar.CustomerRole)
            //    .WithMany()
            //    .HasForeignKey(ar => ar.CustomerRoleId)
            //    .WillCascadeOnDelete(true);
        }
        protected override void DoConfig(EntityTypeBuilder<AclRecord> builder)
        {
            builder.ToTable("AclRecord").HasKey(ar => ar.Id);

            builder.Property(ar => ar.EntityName).IsRequired().HasMaxLength(400);

            builder.HasOne(ar => ar.CustomerRole)
                .WithMany()
                .HasForeignKey(ar => ar.CustomerRoleId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}