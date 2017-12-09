﻿using RufaPoint.Tests;
using NUnit.Framework;

namespace RufaPoint.Data.Tests.Shipping
{
    [TestFixture]
    public class WarehousePersistenceTests : PersistenceTest
    {
        [Test]
        public void Can_save_and_load_warehouse()
        {
            var warehouse = this.GetTestWarehouse();

            var fromDb = SaveAndLoadEntity(this.GetTestWarehouse());
            fromDb.ShouldNotBeNull();
            fromDb.PropertiesShouldEqual(warehouse);
        }
    }
}