using RufaPoint.Tests;
using Xunit;

namespace RufaPoint.Data.Tests.Directory
{

    public class CurrencyPersistenceTests : PersistenceTest
    {
        [Fact]
        public void Can_save_and_load_currency()
        {
            var currency = this.GetTestCurrency();

            var fromDb = SaveAndLoadEntity(currency);
            fromDb.ShouldNotBeNull();
            fromDb.PropertiesShouldEqual(currency);
        }
    }
}
