using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using RufaPoint.Core.Configuration;
using RufaPoint.Core.Plugins;
using RufaPoint.Services.Events;
using Xunit;
using Moq;

namespace RufaPoint.Web.MVC.Tests.Events
{

    public class EventsTests
    {
        private IEventPublisher _eventPublisher;

        public EventsTests()
        {
            PluginManager.Initialize(new ApplicationPartManager(), new CoreAppConfig());
            var subscriptionService = new Mock<ISubscriptionService>();
            var consumers = new List<IConsumer<DateTime>> {new DateTimeConsumer()};
            subscriptionService.Setup(c => c.GetSubscriptions<DateTime>()).Returns(consumers);
            _eventPublisher = new EventPublisher(subscriptionService.Object);
        }

        [Fact]
        public void Can_publish_event()
        {
            var oldDateTime = DateTime.Now.Subtract(TimeSpan.FromDays(7));
            DateTimeConsumer.DateTime = oldDateTime;

            var newDateTime = DateTime.Now.Subtract(TimeSpan.FromDays(5));
            _eventPublisher.Publish(newDateTime);
            Assert.Equal(DateTimeConsumer.DateTime, newDateTime);
        }
    }
}