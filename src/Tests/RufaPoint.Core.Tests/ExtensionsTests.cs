using RufaPoint.Core.Extensions;
using RufaPoint.Tests;
using Xunit;

namespace RufaPoint.Core.Tests
{

    public class ExtensionsTests
    {
        [Fact]
        public void Can_check_IsNullOrDefault()
        {
            int? x1 = null;
            x1.IsNullOrDefault().ShouldBeTrue();

            int? x2 = 0;
            x2.IsNullOrDefault().ShouldBeTrue();

            int? x3 = 1;
            x3.IsNullOrDefault().ShouldBeFalse();
        }
    }
}



