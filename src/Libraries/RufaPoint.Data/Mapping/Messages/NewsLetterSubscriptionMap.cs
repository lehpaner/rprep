using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RufaPoint.Core.Domain.Messages;

namespace RufaPoint.Data.Mapping.Messages
{
    /// <summary>
    /// Mapping class
    /// </summary>
    public partial class NewsLetterSubscriptionMap : NopEntityTypeConfiguration<NewsLetterSubscription>
    {
        /// <summary>
        /// Ctor
        /// </summary>
        public NewsLetterSubscriptionMap()
        {
            //this.ToTable("NewsLetterSubscription");
            //this.HasKey(nls => nls.Id);

            //this.Property(nls => nls.Email).IsRequired().HasMaxLength(255);
        }
        protected override void DoConfig(EntityTypeBuilder<NewsLetterSubscription> builder)
        {
            builder.ToTable("NewsLetterSubscription").HasKey(nls => nls.Id);
            builder.Property(nls => nls.Email).IsRequired().HasMaxLength(255);
        }
    }
}