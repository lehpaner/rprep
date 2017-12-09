using RufaPoint.Tests;
using NUnit.Framework;

namespace RufaPoint.Data.Tests.Orders
{
    [TestFixture]
    public class RecurringPaymentHistoryPersistenceTests : PersistenceTest
    {
        [Test]
        public void Can_save_and_load_recurringPaymentHistory()
        {
            var rph = this.GetTestRecurringPaymentHistory();
            rph.RecurringPayment = this.GetTestRecurringPayment();
            rph.RecurringPayment.InitialOrder.Customer = this.GetTestCustomer();
            var fromDb = SaveAndLoadEntity(rph);
            fromDb.ShouldNotBeNull();
            fromDb.PropertiesShouldEqual(this.GetTestRecurringPaymentHistory());

            fromDb.RecurringPayment.ShouldNotBeNull();
            fromDb.RecurringPayment.PropertiesShouldEqual(this.GetTestRecurringPayment(), "NextPaymentDate", "CyclesRemaining");
        }
    }
}