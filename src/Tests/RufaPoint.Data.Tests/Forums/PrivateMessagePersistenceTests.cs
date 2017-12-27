using System;
using RufaPoint.Tests;
using Xunit;

namespace RufaPoint.Data.Tests.Forums
{
    public class PrivateMessagePersistenceTests : PersistenceTest
    {
        [Fact]
        public void Can_save_and_load_privatemessage()
        {
            var store = this.GetTestStore();
            var storeFromDb = SaveAndLoadEntity(store);
            storeFromDb.ShouldNotBeNull();

            var customer1 = this.GetTestCustomer();
            var customer1FromDb = SaveAndLoadEntity(customer1);
            customer1FromDb.ShouldNotBeNull();

            var customer2 = this.GetTestCustomer();
            customer2.CustomerGuid = Guid.NewGuid();

            var customer2FromDb = SaveAndLoadEntity(customer2);
            customer2FromDb.ShouldNotBeNull();

            var privateMessage = this.GetTestPrivateMessage();
            privateMessage.FromCustomerId = customer1FromDb.Id;
            privateMessage.ToCustomerId = customer2FromDb.Id;
            privateMessage.StoreId = store.Id;

            var fromDb = SaveAndLoadEntity(privateMessage);
            fromDb.ShouldNotBeNull();
            fromDb.PropertiesShouldEqual(this.GetTestPrivateMessage(), "StoreId", "FromCustomerId", "ToCustomerId");
        }
    }
}
