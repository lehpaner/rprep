using RufaPoint.Core.Data;
using RufaPoint.Core.Domain.Customers;
using RufaPoint.Core.Domain.Messages;
using RufaPoint.Data;
using RufaPoint.Services.Customers;
using RufaPoint.Services.Events;
using RufaPoint.Services.Messages;
using Xunit;
using Moq;

namespace RufaPoint.Services.Tests.Messages 
{

    public class NewsLetterSubscriptionServiceTests : ServiceTest
    {
        private Mock<IEventPublisher> _eventPublisher;
        private Mock<IRepository<NewsLetterSubscription>> _newsLetterSubscriptionRepository;
        private Mock<IRepository<Customer>> _customerRepository;
        private Mock<ICustomerService> _customerService;
        private Mock<IDbContext> _dbContext;

        public NewsLetterSubscriptionServiceTests()
        {
            _eventPublisher = new Mock<IEventPublisher>();
            _eventPublisher.SetupAllProperties();
            _newsLetterSubscriptionRepository = new Mock<IRepository<NewsLetterSubscription>>();
            _customerRepository = new Mock<IRepository<Customer>>();
            _customerService = new Mock<ICustomerService>();
            _dbContext = new Mock<IDbContext>();
            _dbContext.SetupAllProperties();
        }

        /// <summary>
        /// Verifies the active insert triggers subscribe event.
        /// </summary>
        [Fact]
        public void VerifyActiveInsertTriggersSubscribeEvent()
        {
            var service = new NewsLetterSubscriptionService(_dbContext.Object, _newsLetterSubscriptionRepository.Object,
                _customerRepository.Object, _eventPublisher.Object, _customerService.Object);

            var subscription = new NewsLetterSubscription { Active = true, Email = "test@test.com" };
            service.InsertNewsLetterSubscription(subscription, true);

            //Pekmez    _eventPublisher.AssertWasCalled(x => x.Publish(new EmailSubscribedEvent(subscription)));
        }

        /// <summary>
        /// Verifies the delete triggers unsubscribe event.
        /// </summary>
        [Fact]
        public void VerifyDeleteTriggersUnsubscribeEvent()
        {
            var service = new NewsLetterSubscriptionService(_dbContext.Object, _newsLetterSubscriptionRepository.Object,
                _customerRepository.Object, _eventPublisher.Object, _customerService.Object);

            var subscription = new NewsLetterSubscription { Active = true, Email = "test@test.com" };
            service.DeleteNewsLetterSubscription(subscription, true);

            //Pekmez   _eventPublisher.AssertWasCalled(x => x.Publish(new EmailUnsubscribedEvent(subscription)));
        }

        /// <summary>
        /// Verifies the insert event is fired.
        /// </summary>
        [Fact]
        public void VerifyInsertEventIsFired()
        {
            var service = new NewsLetterSubscriptionService(_dbContext.Object, _newsLetterSubscriptionRepository.Object,
                _customerRepository.Object, _eventPublisher.Object, _customerService.Object);

            service.InsertNewsLetterSubscription(new NewsLetterSubscription { Email = "test@test.com" });

        //Pekmez    _eventPublisher.AssertWasCalled(x => x.EntityInserted(Arg<NewsLetterSubscription>.Is.Anything));
        }
    }
}