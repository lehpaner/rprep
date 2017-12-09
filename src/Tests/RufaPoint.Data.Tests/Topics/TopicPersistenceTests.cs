﻿using RufaPoint.Tests;
using NUnit.Framework;

namespace RufaPoint.Data.Tests.Topics
{
    [TestFixture]
    public class TopicPersistenceTests : PersistenceTest
    {
        [Test]
        public void Can_save_and_load_topic()
        {
            var topic = this.GetTestTopic();

            var fromDb = SaveAndLoadEntity(this.GetTestTopic());
            fromDb.ShouldNotBeNull();
            fromDb.PropertiesShouldEqual(topic);
        }
    }
}