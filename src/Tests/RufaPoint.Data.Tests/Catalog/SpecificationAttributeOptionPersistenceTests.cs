﻿using RufaPoint.Tests;
using NUnit.Framework;

namespace RufaPoint.Data.Tests.Catalog
{
    [TestFixture]
    public class SpecificationAttributeOptionPersistenceTests : PersistenceTest
    {
        [Test]
        public void Can_save_and_load_specificationAttributeOption()
        {
            var specificationAttributeOption = this.GetTestSpecificationAttributeOption();
            specificationAttributeOption.SpecificationAttribute = this.GetTestSpecificationAttribute();

            var fromDb = SaveAndLoadEntity(specificationAttributeOption);
            fromDb.ShouldNotBeNull();
            fromDb.PropertiesShouldEqual(this.GetTestSpecificationAttributeOption());

            fromDb.SpecificationAttribute.ShouldNotBeNull();
            fromDb.SpecificationAttribute.PropertiesShouldEqual(this.GetTestSpecificationAttribute());
        }
    }
}
