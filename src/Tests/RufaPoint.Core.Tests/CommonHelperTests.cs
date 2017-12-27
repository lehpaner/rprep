using RufaPoint.Tests;
using Xunit;

namespace RufaPoint.Core.Tests
{
    public class CommonHelperTests
    {
        [Fact]
        public void Can_get_typed_value()
        {
            CommonHelper.To<int>("1000").ShouldBe<int>();
            CommonHelper.To<int>("1000").ShouldEqual(1000);
        }
    }
}
