using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RufaPoint.Core.Domain.Customers;

namespace RufaPoint.Data.Mapping.Customers
{
    /// <summary>
    /// Mapping class
    /// </summary>
    public partial class ExternalAuthenticationRecordMap : NopEntityTypeConfiguration<ExternalAuthenticationRecord>
    {
        /// <summary>
        /// Ctor
        /// </summary>
        public ExternalAuthenticationRecordMap()
        {
            //this.ToTable("ExternalAuthenticationRecord");

            //this.HasKey(ear => ear.Id);

            //this.HasRequired(ear => ear.Customer)
            //    .WithMany(c => c.ExternalAuthenticationRecords)
            //    .HasForeignKey(ear => ear.CustomerId);

        }
        protected override void DoConfig(EntityTypeBuilder<ExternalAuthenticationRecord> builder)
        {
            builder.ToTable("ExternalAuthenticationRecord").HasKey(ear => ear.Id);

            builder.HasOne(ear => ear.Customer)
                .WithMany(c => c.ExternalAuthenticationRecords)
                .HasForeignKey(ear => ear.CustomerId);
        }
    }
}