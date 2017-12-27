using RufaPoint.Tests;
using Xunit;

namespace RufaPoint.Data.Tests.Logging
{

    public class ActivityLogPersistenceTests : PersistenceTest
    {
        [Fact]
        public void Can_save_and_load_activityLogType()
        {
            var activityLogType = this.GetTestActivityLogType();

            var fromDb = SaveAndLoadEntity(this.GetTestActivityLogType());
            fromDb.ShouldNotBeNull();
            fromDb.PropertiesShouldEqual(activityLogType);
        }
    }
}