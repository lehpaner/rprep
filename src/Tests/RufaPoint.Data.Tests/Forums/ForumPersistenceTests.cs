using RufaPoint.Tests;
using Xunit;

namespace RufaPoint.Data.Tests.Forums
{

    public class ForumPersistenceTests : PersistenceTest
    {
        [Fact]
        public void Can_save_and_load_forum()
        {
            var forum = this.GetTestForum();
            forum.ForumGroup = this.GetTestForumGroup();

            var fromDb = SaveAndLoadEntity(forum);
            fromDb.ShouldNotBeNull();
            fromDb.PropertiesShouldEqual(this.GetTestForum());

            fromDb.ForumGroup.ShouldNotBeNull();
            fromDb.ForumGroup.PropertiesShouldEqual(this.GetTestForumGroup());
        }
    }
}