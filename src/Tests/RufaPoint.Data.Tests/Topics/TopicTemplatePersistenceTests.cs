using RufaPoint.Tests;
using Xunit;

namespace RufaPoint.Data.Tests.Topics
{

    public class TopicTemplatePersistenceTests : PersistenceTest
    {
        [Fact]
        public void Can_save_and_load_topicTemplate()
        {
            var topicTemplate = this.GetTestTopicTemplate();

            var fromDb = SaveAndLoadEntity(this.GetTestTopicTemplate());
            fromDb.ShouldNotBeNull();
            fromDb.PropertiesShouldEqual(topicTemplate);
        }
    }
}
