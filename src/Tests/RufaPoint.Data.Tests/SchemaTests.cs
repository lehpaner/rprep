using Microsoft.EntityFrameworkCore.Storage;
using RufaPoint.Tests;
using Xunit;

namespace RufaPoint.Data.Tests
{
    public class SchemaTests
    {
        [Fact]
        public void Can_generate_schema()
        {
            //Database.SetInitializer<AppObjectContext>(null);
            var ctx = new AppObjectContext("Test");
            var result = ctx.CreateDatabaseScript();
            result.ShouldNotBeNull();
        }
    }
}
