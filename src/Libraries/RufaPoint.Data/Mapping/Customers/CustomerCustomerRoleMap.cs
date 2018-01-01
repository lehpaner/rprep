using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RufaPoint.Core.Domain.Customers;

namespace RufaPoint.Data.Mapping.Customers
{
    public class CustomerCustomerRoleMap : NopEntityTypeConfiguration<CustomerCustomerRole>
    {
        public CustomerCustomerRoleMap()
        {
        }
        protected override void DoConfig(EntityTypeBuilder<CustomerCustomerRole> builder)
        {
            builder.ToTable("Customer_CustomerRole_Mapping").HasKey(c => new { c.CustomerId, c.CustomerRoleId });
            builder.HasOne(c => c.Customer).WithMany(cr => cr.CustomerRoles).HasForeignKey(cfk => cfk.CustomerId);
            builder.HasOne(r => r.CustomerRole).WithMany(cc => cc.CustomerRoles).HasForeignKey(cfk => cfk.CustomerRoleId);
        }
    }
}
