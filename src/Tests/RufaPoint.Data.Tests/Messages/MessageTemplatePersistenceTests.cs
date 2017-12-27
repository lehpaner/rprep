using RufaPoint.Tests;
using Xunit;

namespace RufaPoint.Data.Tests.Messages
{

    public class MessageTemplatePersistenceTests : PersistenceTest
    {
        [Fact]
        public void Can_save_and_load_messageTemplate()
        {
            var mt = this.GetTestMessageTemplate();

            var fromDb = SaveAndLoadEntity(this.GetTestMessageTemplate());
            fromDb.ShouldNotBeNull();
            fromDb.PropertiesShouldEqual(mt);
        }
    }
}