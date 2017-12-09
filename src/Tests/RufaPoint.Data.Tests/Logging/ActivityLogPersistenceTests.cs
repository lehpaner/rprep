using RufaPoint.Tests;
using NUnit.Framework;

namespace RufaPoint.Data.Tests.Logging
{
    [TestFixture]
    public class ActivityLogPersistenceTests : PersistenceTest
    {
        [Test]
        public void Can_save_and_load_activityLogType()
        {
            var activityLogType = this.GetTestActivityLogType();

            var fromDb = SaveAndLoadEntity(this.GetTestActivityLogType());
            fromDb.ShouldNotBeNull();
            fromDb.PropertiesShouldEqual(activityLogType);
        }
    }
}