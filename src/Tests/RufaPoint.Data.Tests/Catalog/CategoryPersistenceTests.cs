﻿using RufaPoint.Tests;
using NUnit.Framework;

namespace RufaPoint.Data.Tests.Catalog
{
    [TestFixture]
    public class CategoryPersistenceTests : PersistenceTest
    {
        [Test]
        public void Can_save_and_load_category()
        {
            var category = this.GetTestCategory();

            var fromDb = SaveAndLoadEntity(this.GetTestCategory());
            fromDb.ShouldNotBeNull();
            fromDb.PropertiesShouldEqual(category);
        }        
    }
}