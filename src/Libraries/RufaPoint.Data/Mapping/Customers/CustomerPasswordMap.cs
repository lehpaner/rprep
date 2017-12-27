using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RufaPoint.Core.Domain.Customers;

namespace RufaPoint.Data.Mapping.Customers
{
    /// <summary>
    /// Mapping class
    /// </summary>
    public partial class CustomerPasswordMap : NopEntityTypeConfiguration<CustomerPassword>
    {
        /// <summary>
        /// Ctor
        /// </summary>
        public CustomerPasswordMap()
        {
            //this.ToTable("CustomerPassword");
            //this.HasKey(password => password.Id);

            //this.HasRequired(password => password.Customer)
            //    .WithMany()
            //    .HasForeignKey(password => password.CustomerId);

            //this.Ignore(password => password.PasswordFormat);
        }
        protected override void DoConfig(EntityTypeBuilder<CustomerPassword> builder)
        {
            builder.ToTable("CustomerPassword").HasKey(password => password.Id);

            builder.HasOne(password => password.Customer)
                .WithMany()
                .HasForeignKey(password => password.CustomerId);

            builder.Ignore(password => password.PasswordFormat);
        }
    }
}