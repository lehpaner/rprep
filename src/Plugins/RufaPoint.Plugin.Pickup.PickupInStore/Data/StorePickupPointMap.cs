using RufaPoint.Data.Mapping;
using RufaPoint.Plugin.Pickup.PickupInStore.Domain;

namespace RufaPoint.Plugin.Pickup.PickupInStore.Data
{
    public partial class StorePickupPointMap : NopEntityTypeConfiguration<StorePickupPoint>
    {
        public StorePickupPointMap()
        {
            this.ToTable("StorePickupPoint");
            this.HasKey(point => point.Id);
            this.Property(point => point.PickupFee).HasPrecision(18, 4);
        }
    }
}