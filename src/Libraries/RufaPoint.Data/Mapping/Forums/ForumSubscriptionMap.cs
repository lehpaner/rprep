using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RufaPoint.Core.Domain.Forums;

namespace RufaPoint.Data.Mapping.Forums
{
    /// <summary>
    /// Mapping class
    /// </summary>
    public partial class ForumSubscriptionMap : NopEntityTypeConfiguration<ForumSubscription>
    {
        /// <summary>
        /// Ctor
        /// </summary>
        public ForumSubscriptionMap()
        {
            //this.ToTable("Forums_Subscription");
            //this.HasKey(fs => fs.Id);

            //this.HasRequired(fs => fs.Customer)
            //    .WithMany()
            //    .HasForeignKey(fs => fs.CustomerId)
            //    .WillCascadeOnDelete(false);
        }
        protected override void DoConfig(EntityTypeBuilder<ForumSubscription> builder)
        {
            builder.ToTable("Forums_Subscription").HasKey(fs => fs.Id);

            builder.HasOne(fs => fs.Customer)
                .WithMany()
                .HasForeignKey(fs => fs.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
