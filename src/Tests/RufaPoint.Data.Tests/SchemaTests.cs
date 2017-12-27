using RufaPoint.Tests;
using Xunit;

namespace RufaPoint.Data.Tests
{
    public class SchemaTests
    {
        [Fact]
        public void Can_generate_schema()
        {
            //Database.SetInitializer<NopObjectContext>(null);
            var ctx = new NopObjectContext("Test");
            var result = ctx.CreateDatabaseScript();
            result.ShouldNotBeNull();
        }
    }
}
