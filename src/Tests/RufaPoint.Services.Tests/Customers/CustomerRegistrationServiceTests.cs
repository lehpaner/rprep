using System;
using System.Collections.Generic;
using System.Linq;
using RufaPoint.Core;
using RufaPoint.Core.Caching;
using RufaPoint.Core.Data;
using RufaPoint.Core.Domain.Common;
using RufaPoint.Core.Domain.Customers;
using RufaPoint.Core.Domain.Forums;
using RufaPoint.Core.Domain.Orders;
using RufaPoint.Core.Domain.Security;
using RufaPoint.Services.Common;
using RufaPoint.Services.Customers;
using RufaPoint.Services.Events;
using RufaPoint.Services.Localization;
using RufaPoint.Services.Messages;
using RufaPoint.Services.Orders;
using RufaPoint.Services.Security;
using RufaPoint.Services.Stores;
using RufaPoint.Tests;
using Xunit;
using Moq;

namespace RufaPoint.Services.Tests.Customers
{
    public class CustomerRegistrationServiceTests : ServiceTest
    {
        private Mock<IRepository<Customer>> _customerRepo;
        private Mock<IRepository<CustomerPassword>> _customerPasswordRepo;
        private Mock<IRepository<CustomerRole>> _customerRoleRepo;
        private Mock<IRepository<GenericAttribute>> _genericAttributeRepo;
        private Mock<IRepository<Order>> _orderRepo;
        private Mock<IRepository<ForumPost>> _forumPostRepo;
        private Mock<IRepository<ForumTopic>> _forumTopicRepo;
        private Mock<IGenericAttributeService> _genericAttributeService;
        private IEncryptionService _encryptionService;
        private ICustomerService _customerService;
        private ICustomerRegistrationService _customerRegistrationService;
        private Mock<ILocalizationService> _localizationService;
        private CustomerSettings _customerSettings;
        private Mock<INewsLetterSubscriptionService> _newsLetterSubscriptionService;
        private Mock<IEventPublisher> _eventPublisher;
        private Mock<IStoreService> _storeService;
        private RewardPointsSettings _rewardPointsSettings;
        private SecuritySettings _securitySettings;
        private Mock<IRewardPointService> _rewardPointService;
        private Mock<IWorkContext> _workContext;
        private Mock<IWorkflowMessageService> _workflowMessageService;

        public CustomerRegistrationServiceTests()
        {
            _customerSettings = new CustomerSettings
            {
                UnduplicatedPasswordsNumber = 1,
                HashedPasswordFormat = "SHA512"
            };
            _securitySettings = new SecuritySettings
            {
                EncryptionKey = "273ece6f97dd844d"
            };
            _rewardPointsSettings = new RewardPointsSettings
            {
                Enabled = false,
            };

            _encryptionService = new EncryptionService(_securitySettings);
            _customerRepo = new Mock<IRepository<Customer>>();
            var customer1 = new Customer
            {
                Id = 1,
                Username = "a@b.com",
                Email = "a@b.com",
                Active = true
            };
            AddCustomerToRegisteredRole(customer1);

            var customer2 = new Customer
            {
                Id = 2,
                Username = "test@test.com",
                Email = "test@test.com",
                Active = true
            };
            AddCustomerToRegisteredRole(customer2);

            var customer3 = new Customer
            {
                Id = 3,
                Username = "user@test.com",
                Email = "user@test.com",
                Active = true
            };
            AddCustomerToRegisteredRole(customer3);

            var customer4 = new Customer
            {
                Id = 4,
                Username = "registered@test.com",
                Email = "registered@test.com",
                Active = true
            };
            AddCustomerToRegisteredRole(customer4);

            var customer5 = new Customer
            {
                Id = 5,
                Username = "notregistered@test.com",
                Email = "notregistered@test.com",
                Active = true
            };
            _customerRepo.Setup(x => x.Table).Returns(new List<Customer> { customer1, customer2, customer3, customer4, customer5 }.AsQueryable());

            _customerPasswordRepo = new Mock<IRepository<CustomerPassword>>();
            var saltKey = _encryptionService.CreateSaltKey(5);
            var password = _encryptionService.CreatePasswordHash("password", saltKey, "SHA512");
            var password1 = new CustomerPassword
            {
                CustomerId = customer1.Id,
                PasswordFormat = PasswordFormat.Hashed,
                PasswordSalt = saltKey,
                Password = password,
                CreatedOnUtc = DateTime.UtcNow
            };
            var password2 = new CustomerPassword
            {
                CustomerId = customer2.Id,
                PasswordFormat = PasswordFormat.Clear,
                Password = "password",
                CreatedOnUtc = DateTime.UtcNow
            };
            var password3 = new CustomerPassword
            {
                CustomerId = customer3.Id,
                PasswordFormat = PasswordFormat.Encrypted,
                Password = _encryptionService.EncryptText("password"),
                CreatedOnUtc = DateTime.UtcNow
            };
            var password4 = new CustomerPassword
            {
                CustomerId = customer4.Id,
                PasswordFormat = PasswordFormat.Clear,
                Password = "password",
                CreatedOnUtc = DateTime.UtcNow
            };
            var password5 = new CustomerPassword
            {
                CustomerId = customer5.Id,
                PasswordFormat = PasswordFormat.Clear,
                Password = "password",
                CreatedOnUtc = DateTime.UtcNow
            };
            _customerPasswordRepo.Setup(x => x.Table).Returns(new[] { password1, password2, password3, password4, password5 }.AsQueryable());

            _eventPublisher = new Mock<IEventPublisher>();
            _eventPublisher.Setup(x => x.Publish(It.IsAny<object>()));


            _storeService = new Mock<IStoreService>();
            _customerRoleRepo = new Mock<IRepository<CustomerRole>>();
            _genericAttributeRepo = new Mock<IRepository<GenericAttribute>>();
            _orderRepo = new Mock<IRepository<Order>>();
            _forumPostRepo = new Mock<IRepository<ForumPost>>();
            _forumTopicRepo = new Mock<IRepository<ForumTopic>>();

            _genericAttributeService = new Mock<IGenericAttributeService>();
            _newsLetterSubscriptionService = new Mock<INewsLetterSubscriptionService>();
            _rewardPointService = new Mock<IRewardPointService>();

            _localizationService = new Mock<ILocalizationService>();
            _workContext = new Mock<IWorkContext>();
            _workflowMessageService = new Mock<IWorkflowMessageService>();

            _customerService = new CustomerService(new DummyCacheManager(), _customerRepo.Object, _customerPasswordRepo.Object, _customerRoleRepo.Object,
                _genericAttributeRepo.Object, _orderRepo.Object, _forumPostRepo.Object, _forumTopicRepo.Object,
                null, null, null, null, null,
                _genericAttributeService.Object, null, null, _eventPublisher.Object, _customerSettings, null);
            _customerRegistrationService = new CustomerRegistrationService(_customerService,
                _encryptionService, _newsLetterSubscriptionService.Object, _localizationService.Object,
                _storeService.Object, _rewardPointService.Object, _workContext.Object, _genericAttributeService.Object,
                _workflowMessageService.Object, _eventPublisher.Object, _rewardPointsSettings, _customerSettings);
        }

        //[Test]
        //public void Can_register_a_customer() 
        //{
        //    var registrationRequest = CreateCustomerRegistrationRequest();
        //    var result = _customerService.RegisterCustomer(registrationRequest);

        //    result.Success.ShouldBeTrue();
        //}

        //[Test]
        //public void Can_not_have_duplicate_usernames_or_emails() 
        //{
        //    var registrationRequest = CreateUserRegistrationRequest();
        //    registrationRequest.Username = "a@b.com";
        //    registrationRequest.Email = "a@b.com";

        //    var userService = new UserService(_encryptionService, _userRepo, _userSettings);
        //    var result = userService.RegisterUser(registrationRequest);

        //    result.Success.ShouldBeFalse();
        //    result.Errors.Count.ShouldEqual(1);
        //}

        [Fact]
        public void Ensure_only_registered_customers_can_login()
        {
            var result = _customerRegistrationService.ValidateCustomer("registered@test.com", "password");
            result.ShouldEqual(CustomerLoginResults.Successful);

            result = _customerRegistrationService.ValidateCustomer("notregistered@test.com", "password");
            result.ShouldEqual(CustomerLoginResults.NotRegistered);
        }

        [Fact]
        public void Can_validate_a_hashed_password()
        {
            var result = _customerRegistrationService.ValidateCustomer("a@b.com", "password");
            result.ShouldEqual(CustomerLoginResults.Successful);
        }

        [Fact]
        public void Can_validate_a_clear_password()
        {
            var result = _customerRegistrationService.ValidateCustomer("test@test.com", "password");
            result.ShouldEqual(CustomerLoginResults.Successful); ;
        }

        [Fact]
        public void Can_validate_an_encrypted_password()
        {
            var result = _customerRegistrationService.ValidateCustomer("user@test.com", "password");
            result.ShouldEqual(CustomerLoginResults.Successful);
        }

        private void AddCustomerToRegisteredRole(Customer customer)
        {
            var registred = new CustomerRole
            {
                Active = true,
                IsSystemRole = true,
                SystemName = SystemCustomerRoleNames.Registered
            };
            customer.CustomerRoles.Add(new CustomerCustomerRole
            {
                Customer = customer,
                CustomerId = customer.Id,
                CustomerRole = registred,
                CustomerRoleId= registred.Id
            });
        }

        [Fact]
        public void Can_change_password()
        {
            var request = new ChangePasswordRequest("registered@test.com", true, PasswordFormat.Clear, "password", "password");
            var result = _customerRegistrationService.ChangePassword(request);
            result.Success.ShouldEqual(false);

            request = new ChangePasswordRequest("registered@test.com", true, PasswordFormat.Hashed, "newpassword", "password");
            result = _customerRegistrationService.ChangePassword(request);
            result.Success.ShouldEqual(true);

            //request = new ChangePasswordRequest("registered@test.com", true, PasswordFormat.Encrypted, "password", "newpassword");
            //result = _customerRegistrationService.ChangePassword(request);
            //result.Success.ShouldEqual(true);
        }

    }
}
