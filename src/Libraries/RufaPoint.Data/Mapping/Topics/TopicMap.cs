using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RufaPoint.Core.Domain.Topics;

namespace RufaPoint.Data.Mapping.Topics
{
    /// <summary>
    /// Mapping class
    /// </summary>
    public class TopicMap : NopEntityTypeConfiguration<Topic>
    {
        /// <summary>
        /// Ctor
        /// </summary>
        public TopicMap()
        {
            //this.ToTable("Topic");
            //this.HasKey(t => t.Id);
        }
        protected override void DoConfig(EntityTypeBuilder<Topic> builder)
        {
            builder.ToTable("Topic").HasKey(t => t.Id);
        }
    }
}
