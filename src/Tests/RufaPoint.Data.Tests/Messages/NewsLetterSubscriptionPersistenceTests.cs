using RufaPoint.Tests;
using Xunit;

namespace RufaPoint.Data.Tests.Messages
{

    public class NewsLetterSubscriptionPersistenceTests : PersistenceTest
    {
        [Fact]
        public void Can_save_and_load_nls()
        {
            var nls = this.GetTestNewsLetterSubscription();

            var fromDb = SaveAndLoadEntity(this.GetTestNewsLetterSubscription());
            fromDb.ShouldNotBeNull();
            fromDb.PropertiesShouldEqual(nls);
        }
    }
}