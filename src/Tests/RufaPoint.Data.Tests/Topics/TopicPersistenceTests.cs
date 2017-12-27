using RufaPoint.Tests;
using Xunit;

namespace RufaPoint.Data.Tests.Topics
{

    public class TopicPersistenceTests : PersistenceTest
    {
        [Fact]
        public void Can_save_and_load_topic()
        {
            var topic = this.GetTestTopic();

            var fromDb = SaveAndLoadEntity(this.GetTestTopic());
            fromDb.ShouldNotBeNull();
            fromDb.PropertiesShouldEqual(topic);
        }
    }
}