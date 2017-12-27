using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RufaPoint.Core.Domain.Tasks;

namespace RufaPoint.Data.Mapping.Tasks
{
    /// <summary>
    /// Mapping class
    /// </summary>
    public partial class ScheduleTaskMap : NopEntityTypeConfiguration<ScheduleTask>
    {
        /// <summary>
        /// Ctor
        /// </summary>
        public ScheduleTaskMap()
        {
            //this.ToTable("ScheduleTask");
            //this.HasKey(t => t.Id);
            //this.Property(t => t.Name).IsRequired();
            //this.Property(t => t.Type).IsRequired();
        }
        protected override void DoConfig(EntityTypeBuilder<ScheduleTask> builder)
        {
            builder.ToTable("ScheduleTask").HasKey(t => t.Id);
            builder.Property(t => t.Name).IsRequired();
            builder.Property(t => t.Type).IsRequired();
        }
    }
}