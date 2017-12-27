﻿using System.Linq;
using RufaPoint.Tests;
using Xunit;

namespace RufaPoint.Data.Tests.Directory
{

    public class CountryPersistenceTests : PersistenceTest
    {
        [Fact]
        public void Can_save_and_load_country()
        {
            var country = this.GetTestCountry();

            var fromDb = SaveAndLoadEntity(this.GetTestCountry());
            fromDb.ShouldNotBeNull();
            fromDb.PropertiesShouldEqual(country);
        }

        [Fact]
        public void Can_save_and_load_country_with_states()
        {
            var country = this.GetTestCountry();
            country.StateProvinces.Add(this.GetTestStateProvince());
            var fromDb = SaveAndLoadEntity(country);
            fromDb.ShouldNotBeNull();
            fromDb.PropertiesShouldEqual(this.GetTestCountry());

            fromDb.StateProvinces.ShouldNotBeNull();
            (fromDb.StateProvinces.Count == 1).ShouldBeTrue();
            fromDb.StateProvinces.First().PropertiesShouldEqual(this.GetTestStateProvince());
        }

        [Fact]
        public void Can_save_and_load_country_with_restrictions()
        {
            var country = this.GetTestCountry();
            country.RestrictedShippingMethods.Add(this.GetTestShippingMethod());
            var fromDb = SaveAndLoadEntity(country);
            fromDb.ShouldNotBeNull();
            fromDb.PropertiesShouldEqual(this.GetTestCountry());

            fromDb.RestrictedShippingMethods.ShouldNotBeNull();
            (fromDb.RestrictedShippingMethods.Count == 1).ShouldBeTrue();
            fromDb.RestrictedShippingMethods.First().PropertiesShouldEqual(this.GetTestShippingMethod());
        }
    }
}
