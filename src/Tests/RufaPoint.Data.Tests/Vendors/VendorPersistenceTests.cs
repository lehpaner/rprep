using System.Linq;
using RufaPoint.Tests;
using Xunit;

namespace RufaPoint.Data.Tests.Vendors
{

    public class VendorPersistenceTests : PersistenceTest
    {
        [Fact]
        public void Can_save_and_load_vendor()
        {
            var vendor = this.GetTestVendor();

            var fromDb = SaveAndLoadEntity(this.GetTestVendor());
            fromDb.ShouldNotBeNull();
            fromDb.PropertiesShouldEqual(vendor);
        }

        [Fact]
        public void Can_save_and_load_vendor_with_vendorNotes()
        {
            var vendor = this.GetTestVendor();

            vendor.VendorNotes.Add(this.GetTestVendorNote());
            var fromDb = SaveAndLoadEntity(vendor);
            fromDb.ShouldNotBeNull();
            fromDb.PropertiesShouldEqual(this.GetTestVendor());

            fromDb.VendorNotes.ShouldNotBeNull();
            fromDb.VendorNotes.First().PropertiesShouldEqual(this.GetTestVendorNote());
        }
    }
}
