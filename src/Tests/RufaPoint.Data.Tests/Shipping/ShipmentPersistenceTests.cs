using System.Linq;
using RufaPoint.Tests;
using Xunit;

namespace RufaPoint.Data.Tests.Shipping
{

    public class ShipmentPersistenceTests : PersistenceTest
    {
        [Fact]
        public void Can_save_and_load_shipment()
        {
            var shipment = this.GetTestShipment();
            shipment.Order.Customer = this.GetTestCustomer();
            var fromDb = SaveAndLoadEntity(shipment);
            fromDb.ShouldNotBeNull();
            fromDb.PropertiesShouldEqual(this.GetTestShipment());
        }

        [Fact]
        public void Can_save_and_load_shipment_with_items()
        {
            var shipment = this.GetTestShipment();
            shipment.ShipmentItems.Add(this.GetTestShipmentItem());
            shipment.Order.Customer = this.GetTestCustomer();
            var fromDb = SaveAndLoadEntity(shipment);
            fromDb.ShouldNotBeNull();
            fromDb.PropertiesShouldEqual(this.GetTestShipment());

            fromDb.ShipmentItems.ShouldNotBeNull();
            (fromDb.ShipmentItems.Count == 1).ShouldBeTrue();
            fromDb.ShipmentItems.First().PropertiesShouldEqual(this.GetTestShipmentItem());
        }
    }
}