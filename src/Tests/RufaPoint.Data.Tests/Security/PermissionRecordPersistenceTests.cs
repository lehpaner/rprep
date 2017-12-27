using System.Linq;
using RufaPoint.Tests;
using Xunit;

namespace RufaPoint.Data.Tests.Security
{

    public class PermissionRecordPersistenceTests : PersistenceTest
    {
        [Fact]
        public void Can_save_and_load_permissionRecord()
        {
            var permissionRecord = this.GetTestPermissionRecord();

            var fromDb = SaveAndLoadEntity(this.GetTestPermissionRecord());
            fromDb.ShouldNotBeNull();
            fromDb.PropertiesShouldEqual(permissionRecord);
        }

        [Fact]
        public void Can_save_and_load_permissionRecord_with_customerRoles()
        {
            var permissionRecord = this.GetTestPermissionRecord();
            permissionRecord.CustomerRoles.Add(this.GetTestCustomerRole());
            
            var fromDb = SaveAndLoadEntity(permissionRecord);
            fromDb.ShouldNotBeNull();
            fromDb.PropertiesShouldEqual(this.GetTestPermissionRecord());

            fromDb.CustomerRoles.ShouldNotBeNull();
            (fromDb.CustomerRoles.Count == 1).ShouldBeTrue();
            fromDb.CustomerRoles.First().PropertiesShouldEqual(this.GetTestCustomerRole());
        }
    }
}
