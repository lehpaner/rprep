using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RufaPoint.Core.Domain.Orders;

namespace RufaPoint.Data.Mapping.Orders
{
    /// <summary>
    /// Mapping class
    /// </summary>
    public partial class OrderNoteMap : NopEntityTypeConfiguration<OrderNote>
    {
        /// <summary>
        /// Ctor
        /// </summary>
        public OrderNoteMap()
        {
            //this.ToTable("OrderNote");
            //this.HasKey(on => on.Id);
            //this.Property(on => on.Note).IsRequired();

            //this.HasRequired(on => on.Order)
            //    .WithMany(o => o.OrderNotes)
            //    .HasForeignKey(on => on.OrderId);
        }
        protected override void DoConfig(EntityTypeBuilder<OrderNote> builder)
        {
            builder.ToTable("OrderNote").HasKey(on => on.Id);
            builder.Property(on => on.Note).IsRequired();

            builder.HasOne(on => on.Order)
                .WithMany(o => o.OrderNotes)
                .HasForeignKey(on => on.OrderId);
        }
    }
}