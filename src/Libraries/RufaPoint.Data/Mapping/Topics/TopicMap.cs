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
            this.ToTable("Topic");
            this.HasKey(t => t.Id);
        }
    }
}
