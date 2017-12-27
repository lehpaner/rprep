using System.Linq;
using RufaPoint.Core.Infrastructure;
using RufaPoint.Tests;
using Xunit;

namespace RufaPoint.Core.Tests.Infrastructure
{

    public class TypeFinderTests
    {
        [Fact]
        public void TypeFinder_Benchmark_Findings()
        {
            var finder = new AppDomainTypeFinder();

            var type = finder.FindClassesOfType<ISomeInterface>();
            type.Count().ShouldEqual(1);
            typeof(ISomeInterface).IsAssignableFrom(type.FirstOrDefault()).ShouldBeTrue();
        }

        public interface ISomeInterface
        {
        }

        public class SomeClass : ISomeInterface
        {
        }
    }
}
