using RufaPoint.Tests;
using Xunit;

namespace RufaPoint.Data.Tests.Vendors
{
    public class VendorNotePersistenceTests : PersistenceTest
    {
        [Fact]
        public void Can_save_and_load_vendorNote()
        {
            var on = this.GetTestVendorNote();
            on.Vendor = this.GetTestVendor();

            var fromDb = SaveAndLoadEntity(on);
            fromDb.ShouldNotBeNull();
            fromDb.PropertiesShouldEqual(this.GetTestVendorNote());

            fromDb.Vendor.ShouldNotBeNull();
            fromDb.Vendor.PropertiesShouldEqual(this.GetTestVendor());
        }
    }
}