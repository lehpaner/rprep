using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RufaPoint.Core.Domain.Customers;

namespace RufaPoint.Data.Mapping.Customers
{
    /// <summary>
    /// Mapping class
    /// </summary>
    public partial class CustomerRoleMap : NopEntityTypeConfiguration<CustomerRole>
    {
        /// <summary>
        /// Ctor
        /// </summary>
        public CustomerRoleMap()
        {
            //this.ToTable("CustomerRole");
            //this.HasKey(cr => cr.Id);
            //this.Property(cr => cr.Name).IsRequired().HasMaxLength(255);
            //this.Property(cr => cr.SystemName).HasMaxLength(255);
        }
        protected override void DoConfig(EntityTypeBuilder<CustomerRole> builder)
        {
            builder.ToTable("CustomerRole").HasKey(cr => cr.Id);
            builder.Property(cr => cr.Name).IsRequired().HasMaxLength(255);
            builder.Property(cr => cr.SystemName).HasMaxLength(255);
            builder.Ignore(i => i.PermissionRecords);//Pekmez
        }
    }
}