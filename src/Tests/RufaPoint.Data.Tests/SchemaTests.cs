using System.Data.Entity;
using RufaPoint.Tests;
using NUnit.Framework;

namespace RufaPoint.Data.Tests
{
    [TestFixture]
    public class SchemaTests
    {
        [Test]
        public void Can_generate_schema()
        {
            Database.SetInitializer<NopObjectContext>(null);
            var ctx = new NopObjectContext("Test");
            var result = ctx.CreateDatabaseScript();
            result.ShouldNotBeNull();
        }
    }
}
