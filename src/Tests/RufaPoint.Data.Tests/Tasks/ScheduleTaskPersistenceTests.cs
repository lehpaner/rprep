using RufaPoint.Tests;
using Xunit;

namespace RufaPoint.Data.Tests.Tasks
{

    public class ScheduleTaskPersistenceTests : PersistenceTest
    {
        [Fact]
        public void Can_save_and_load_scheduleTask()
        {
            var scheduleTask = this.GetTestScheduleTask();

            var fromDb = SaveAndLoadEntity(this.GetTestScheduleTask());
            fromDb.ShouldNotBeNull();
            fromDb.PropertiesShouldEqual(scheduleTask);
        }
    }
}