using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RufaPoint.Core.Domain.Topics;

namespace RufaPoint.Data.Mapping.Topics
{
    /// <summary>
    /// Mapping class
    /// </summary>
    public partial class TopicTemplateMap : NopEntityTypeConfiguration<TopicTemplate>
    {
        /// <summary>
        /// Ctor
        /// </summary>
        public TopicTemplateMap()
        {
            //this.ToTable("TopicTemplate");
            //this.HasKey(t => t.Id);
            //this.Property(t => t.Name).IsRequired().HasMaxLength(400);
            //this.Property(t => t.ViewPath).IsRequired().HasMaxLength(400);
        }
        protected override void DoConfig(EntityTypeBuilder<TopicTemplate> builder)
        {
            builder.ToTable("TopicTemplate").HasKey(t => t.Id);
            builder.Property(t => t.Name).IsRequired().HasMaxLength(400);
            builder.Property(t => t.ViewPath).IsRequired().HasMaxLength(400);
        }
    }
}