using RufaPoint.Tests;
using NUnit.Framework;

namespace RufaPoint.Data.Tests.Topics
{
    [TestFixture]
    public class TopicTemplatePersistenceTests : PersistenceTest
    {
        [Test]
        public void Can_save_and_load_topicTemplate()
        {
            var topicTemplate = this.GetTestTopicTemplate();

            var fromDb = SaveAndLoadEntity(this.GetTestTopicTemplate());
            fromDb.ShouldNotBeNull();
            fromDb.PropertiesShouldEqual(topicTemplate);
        }
    }
}
