using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RufaPoint.Core.Domain.Forums;

namespace RufaPoint.Data.Mapping.Forums
{
    /// <summary>
    /// Mapping class
    /// </summary>
    public partial class ForumGroupMap : NopEntityTypeConfiguration<ForumGroup>
    {
        /// <summary>
        /// Ctor
        /// </summary>
        public ForumGroupMap()
        {
            //this.ToTable("Forums_Group");
            //this.HasKey(fg => fg.Id);
            //this.Property(fg => fg.Name).IsRequired().HasMaxLength(200);
        }
        protected override void DoConfig(EntityTypeBuilder<ForumGroup> builder)
        {
            builder.ToTable("Forums_Group").HasKey(fg => fg.Id);
            builder.Property(fg => fg.Name).IsRequired().HasMaxLength(200);
        }
    }
}
