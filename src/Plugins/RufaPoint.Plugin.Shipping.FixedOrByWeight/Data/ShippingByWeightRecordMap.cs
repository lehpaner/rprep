using RufaPoint.Data.Mapping;
using RufaPoint.Plugin.Shipping.FixedOrByWeight.Domain;

namespace RufaPoint.Plugin.Shipping.FixedOrByWeight.Data
{
    public partial class ShippingByWeightRecordMap : NopEntityTypeConfiguration<ShippingByWeightRecord>
    {
        public ShippingByWeightRecordMap()
        {
            this.ToTable("ShippingByWeight");
            this.HasKey(x => x.Id);

            this.Property(x => x.Zip).HasMaxLength(400);
        }
    }
}