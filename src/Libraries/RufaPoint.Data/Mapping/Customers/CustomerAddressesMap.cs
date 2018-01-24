using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RufaPoint.Core.Domain.Customers;

namespace RufaPoint.Data.Mapping.Customers
{
    public class CustomerAddressesMap : NopEntityTypeConfiguration<CustomerAdresses>
    {
        public CustomerAddressesMap()
        {
        }
        protected override void DoConfig(EntityTypeBuilder<CustomerAdresses> builder)
        {
            builder.ToTable("CustomerAdresses").HasKey(c => new { c.CustomerId, c.Address_Id });
            builder.HasOne(c => c.Customer).WithMany(cr => cr.Addresses).HasForeignKey(cfk => cfk.CustomerId);
        }
    }
}
