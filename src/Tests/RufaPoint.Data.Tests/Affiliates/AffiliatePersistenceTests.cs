using RufaPoint.Core.Domain.Affiliates;
using RufaPoint.Tests;
using Xunit;

namespace RufaPoint.Data.Tests.Affiliates
{

    public class AffiliatePersistenceTests : PersistenceTest
    {
        public AffiliatePersistenceTests():base()
        {
            Affiliate testAff = new Affiliate()
            {
                Id = 1,
                Active = true,
            };
            context.Add<Affiliate>(testAff);
        }
        [Fact]
        public void Can_save_and_load_affiliate()
        {
            var affiliate = this.GetTestAffiliate();

            var fromDb = SaveAndLoadEntity(this.GetTestAffiliate());
            fromDb.ShouldNotBeNull();
            fromDb.Address.ShouldNotBeNull();

            fromDb.PropertiesShouldEqual(affiliate);
            fromDb.Address.PropertiesShouldEqual(affiliate.Address);
        }        
    }
}
