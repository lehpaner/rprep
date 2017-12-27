using RufaPoint.Tests;
using Xunit;

namespace RufaPoint.Data.Tests.Shipping
{

    public class ShipmentItemPersistenceTests : PersistenceTest
    {
        [Fact]
        public void Can_save_and_load_shipmentItem()
        {
            var shipmentItem = this.GetTestShipmentItem();
            shipmentItem.Shipment = this.GetTestShipment();
            shipmentItem.Shipment.Order.Customer = this.GetTestCustomer();
            var fromDb = SaveAndLoadEntity(shipmentItem);
            fromDb.ShouldNotBeNull();
            fromDb.PropertiesShouldEqual(this.GetTestShipmentItem());

            fromDb.Shipment.ShouldNotBeNull();
            fromDb.Shipment.PropertiesShouldEqual(this.GetTestShipment());
        }
    }
}