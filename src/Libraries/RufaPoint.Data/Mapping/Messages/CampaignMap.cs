using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RufaPoint.Core.Domain.Messages;

namespace RufaPoint.Data.Mapping.Messages
{
    /// <summary>
    /// Mapping class
    /// </summary>
    public partial class CampaignMap : NopEntityTypeConfiguration<Campaign>
    {
        /// <summary>
        /// Ctor
        /// </summary>
        public CampaignMap()
        {
            //this.ToTable("Campaign");
            //this.HasKey(ea => ea.Id);

            //this.Property(ea => ea.Name).IsRequired();
            //this.Property(ea => ea.Subject).IsRequired();
            //this.Property(ea => ea.Body).IsRequired();
        }
        protected override void DoConfig(EntityTypeBuilder<Campaign> builder)
        {
            builder.ToTable("Campaign").HasKey(ea => ea.Id);

            builder.Property(ea => ea.Name).IsRequired();
            builder.Property(ea => ea.Subject).IsRequired();
            builder.Property(ea => ea.Body).IsRequired();
        }
    }
}