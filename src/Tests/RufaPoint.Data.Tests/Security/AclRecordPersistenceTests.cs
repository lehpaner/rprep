using RufaPoint.Tests;
using Xunit;

namespace RufaPoint.Data.Tests.Security
{

    public class AclRecordPersistenceTests : PersistenceTest
    {
        [Fact]
        public void Can_save_and_load_urlRecord()
        {
            var aclRecord = this.GetTestAclRecord();
            aclRecord.CustomerRole = this.GetTestCustomerRole();

            var fromDb = SaveAndLoadEntity(aclRecord);
            fromDb.ShouldNotBeNull();
            fromDb.PropertiesShouldEqual(this.GetTestAclRecord());
            fromDb.CustomerRole.ShouldNotBeNull();
            fromDb.CustomerRole.PropertiesShouldEqual(this.GetTestCustomerRole());
        }
    }
}
