﻿using RufaPoint.Tests;
using NUnit.Framework;

namespace RufaPoint.Data.Tests.Seo
{
    [TestFixture]
    public class UrlRecordPersistenceTests : PersistenceTest
    {
        [Test]
        public void Can_save_and_load_urlRecord()
        {
            var urlRecord = this.UrlRecord();

            var fromDb = SaveAndLoadEntity(this.UrlRecord());
            fromDb.ShouldNotBeNull();
            fromDb.PropertiesShouldEqual(urlRecord);
        }
    }
}
