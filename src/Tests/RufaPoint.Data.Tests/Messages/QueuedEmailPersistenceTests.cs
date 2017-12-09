using RufaPoint.Tests;
using NUnit.Framework;

namespace RufaPoint.Data.Tests.Messages
{
    [TestFixture]
    public class QueuedEmailPersistenceTests : PersistenceTest
    {
        [Test]
        public void Can_save_and_load_queuedEmail()
        {
            var qe = this.GetTestQueuedEmail();
            qe.EmailAccount = this.GetTestEmailAccount();

            var fromDb = SaveAndLoadEntity(qe);
            fromDb.ShouldNotBeNull();
            fromDb.PropertiesShouldEqual(this.GetTestQueuedEmail());
            fromDb.EmailAccount.ShouldNotBeNull();
            fromDb.EmailAccount.PropertiesShouldEqual(this.GetTestEmailAccount());
        }
    }
}