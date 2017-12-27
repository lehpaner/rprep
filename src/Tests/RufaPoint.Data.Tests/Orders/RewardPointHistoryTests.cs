using RufaPoint.Tests;
using Xunit;

namespace RufaPoint.Data.Tests.Orders
{

    public class RewardPointHistoryTests : PersistenceTest
    {
        [Fact]
        public void Can_save_and_load_rewardPointHistory()
        {
            var rph = this.GetTestRewardPointsHistory();

            var fromDb = SaveAndLoadEntity(this.GetTestRewardPointsHistory());
            fromDb.ShouldNotBeNull();
            fromDb.PropertiesShouldEqual(rph);
        }
    }
}
