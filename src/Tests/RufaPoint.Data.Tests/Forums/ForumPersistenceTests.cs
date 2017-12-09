﻿using RufaPoint.Tests;
using NUnit.Framework;

namespace RufaPoint.Data.Tests.Forums
{
    [TestFixture]
    public class ForumPersistenceTests : PersistenceTest
    {
        [Test]
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