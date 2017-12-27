using RufaPoint.Tests;
using Xunit;

namespace RufaPoint.Data.Tests.Customers
{
    public class RewardPointsHistoryPersistenceTests : PersistenceTest
    {
        [Fact]
        public void Can_save_and_load_rewardPointsHistory()
        {
            var rewardPointsHistory = this.GetTestRewardPointsHistory();

            var fromDb = SaveAndLoadEntity(this.GetTestRewardPointsHistory());
            fromDb.ShouldNotBeNull();
            fromDb.PropertiesShouldEqual(rewardPointsHistory);

            fromDb.Customer.ShouldNotBeNull();
            fromDb.Customer.PropertiesShouldEqual(rewardPointsHistory.Customer);
        }

        [Fact]
        public void Can_save_and_load_rewardPointsHistory_with_order()
        {
            var rewardPointsHistory = this.GetTestRewardPointsHistory();

            var fromDb = SaveAndLoadEntity(this.GetTestRewardPointsHistory());
            fromDb.ShouldNotBeNull();
            fromDb.PropertiesShouldEqual(rewardPointsHistory);

            fromDb.UsedWithOrder.ShouldNotBeNull();
            fromDb.UsedWithOrder.PropertiesShouldEqual(rewardPointsHistory.UsedWithOrder);
        }
    }
}