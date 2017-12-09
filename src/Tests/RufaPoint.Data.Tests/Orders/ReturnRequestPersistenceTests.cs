﻿using RufaPoint.Tests;
using NUnit.Framework;

namespace RufaPoint.Data.Tests.Orders
{
    [TestFixture]
    public class ReturnRequestPersistenceTests : PersistenceTest
    {
        [Test]
        public void Can_save_and_load_returnRequest()
        {
            var rr = this.GetTestReturnRequest();

            var fromDb = SaveAndLoadEntity(this.GetTestReturnRequest());
            fromDb.ShouldNotBeNull();
            fromDb.PropertiesShouldEqual(rr);
        }
    }
}