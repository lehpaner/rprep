using System.Linq;
using RufaPoint.Core.Domain.Common;
using RufaPoint.Core.Domain.Customers;
using RufaPoint.Tests;
using Xunit;

namespace RufaPoint.Core.Tests.Domain.Customers
{

    public class CustomerTests
    {
        [Fact]
        public void Can_check_IsInCustomerRole()
        {
            var customer = new Customer
            {
                /*CustomerRoles = new List<CustomerRole>()
                {
                    new CustomerRole()
                    {
                        Active = true,
                        Name = "Test name 1",
                        SystemName = "Test system name 1",
                    },
                    new CustomerRole()
                    {
                        Active = false,
                        Name = "Test name 2",
                        SystemName = "Test system name 2",
                    },
                }*/
            };
            CustomerRole test1 = new CustomerRole
            {
                Active = true,
                Name = "Test name 1",
                SystemName = "Test system name 1"
            };
            customer.CustomerRoles.Add(new CustomerCustomerRole
            {
                Customer = customer,
                CustomerId = customer.Id,
                CustomerRole = test1,
                CustomerRoleId = test1.Id
            });

            CustomerRole test2 = new CustomerRole
            {
                Active = true,
                Name = "Test name 2",
                SystemName = "Test system name 2"
            };
            customer.CustomerRoles.Add(new CustomerCustomerRole
            {
                Customer = customer,
                CustomerId = customer.Id,
                CustomerRole = test2,
                CustomerRoleId = test2.Id
            });
            customer.IsInCustomerRole("Test system name 1", false).ShouldBeTrue();
            customer.IsInCustomerRole("Test system name 1", true).ShouldBeTrue();

            customer.IsInCustomerRole("Test system name 2", false).ShouldBeTrue();
            customer.IsInCustomerRole("Test system name 2", true).ShouldBeFalse();

            customer.IsInCustomerRole("Test system name 3", false).ShouldBeFalse();
            customer.IsInCustomerRole("Test system name 3", true).ShouldBeFalse();
        }
        [Fact]
        public void Can_check_whether_customer_is_admin()
        {
            var customer = new Customer();
            CustomerRole registred = new CustomerRole
            {
                Active = true,
                Name = "Registered",
                SystemName = SystemCustomerRoleNames.Registered
            };
            customer.CustomerRoles.Add(new CustomerCustomerRole
            {
                Customer = customer,
                CustomerId = customer.Id,
                CustomerRole = registred,
                CustomerRoleId = registred.Id
            });
            CustomerRole guest = new CustomerRole
            {
                Active = true,
                Name = "Guests",
                SystemName = SystemCustomerRoleNames.Guests
            };
            customer.CustomerRoles.Add(new CustomerCustomerRole
            {
                Customer = customer,
                CustomerId = customer.Id,
                CustomerRole = guest,
                CustomerRoleId = guest.Id
            });

            customer.IsAdmin().ShouldBeFalse();
            CustomerRole admin = new CustomerRole
            {
                Active = true,
                Name = "Administrators",
                SystemName = SystemCustomerRoleNames.Administrators
            };
            customer.CustomerRoles.Add(
                new CustomerCustomerRole
                {
                    Customer = customer,
                    CustomerId = customer.Id,
                    CustomerRole = admin,
                    CustomerRoleId = admin.Id
                });
            customer.IsAdmin().ShouldBeTrue();
        }
        [Fact]
        public void Can_check_whether_customer_is_forum_moderator()
        {
            var customer = new Customer();
            CustomerRole registred = new CustomerRole
            {
                Active = true,
                Name = "Registered",
                SystemName = SystemCustomerRoleNames.Registered
            };
            customer.CustomerRoles.Add(new CustomerCustomerRole
            {
                Customer = customer,
                CustomerId = customer.Id,
                CustomerRole = registred,
                CustomerRoleId = registred.Id
            });
            CustomerRole guest = new CustomerRole
            {
                Active = true,
                Name = "Guests",
                SystemName = SystemCustomerRoleNames.Guests
            };
            customer.CustomerRoles.Add(new CustomerCustomerRole
            {
                Customer = customer,
                CustomerId = customer.Id,
                CustomerRole = guest,
                CustomerRoleId = guest.Id
            });

            customer.IsForumModerator().ShouldBeFalse();
            CustomerRole moderator = new CustomerRole
            {
                Active = true,
                Name = "ForumModerators",
                SystemName = SystemCustomerRoleNames.ForumModerators
            };
            customer.CustomerRoles.Add(
                new CustomerCustomerRole
                {
                    Customer = customer,
                    CustomerId = customer.Id,
                    CustomerRole = moderator,
                    CustomerRoleId = moderator.Id
                });
            customer.IsForumModerator().ShouldBeTrue();
        }

        [Fact]
        public void Can_check_whether_customer_is_guest()
        {
            var customer = new Customer();
            CustomerRole registred = new CustomerRole
            {
                Active = true,
                Name = "Registered",
                SystemName = SystemCustomerRoleNames.Registered
            };
            customer.CustomerRoles.Add(new CustomerCustomerRole
            {
                Customer = customer,
                CustomerId = customer.Id,
                CustomerRole = registred,
                CustomerRoleId = registred.Id
            });
            CustomerRole admin = new CustomerRole
            {
                Active = true,
                Name = "Administrators",
                SystemName = SystemCustomerRoleNames.Administrators
            };
            customer.CustomerRoles.Add(new CustomerCustomerRole
            {
                Customer = customer,
                CustomerId = customer.Id,
                CustomerRole = admin,
                CustomerRoleId = admin.Id
            });

            customer.IsGuest().ShouldBeFalse();
            CustomerRole guest = new CustomerRole
            {
                Active = true,
                Name = "Guests",
                SystemName = SystemCustomerRoleNames.Guests
            };
            customer.CustomerRoles.Add(
                new CustomerCustomerRole
                {
                    Customer = customer,
                    CustomerId = customer.Id,
                    CustomerRole = guest,
                    CustomerRoleId = guest.Id
                }
                );
            customer.IsGuest().ShouldBeTrue();
        }
        [Fact]
        public void Can_check_whether_customer_is_registered()
        {
            var customer = new Customer();
            CustomerRole admin = new CustomerRole
            {
                Active = true,
                Name = "Administrators",
                SystemName = SystemCustomerRoleNames.Administrators
            };
            customer.CustomerRoles.Add(new CustomerCustomerRole
            {
                Customer = customer,
                CustomerId = customer.Id,
                CustomerRole = admin,
                CustomerRoleId = admin.Id
            });
            CustomerRole guest = new CustomerRole
            {
                Active = true,
                Name = "Guests",
                SystemName = SystemCustomerRoleNames.Guests
            };
            customer.CustomerRoles.Add(new CustomerCustomerRole
            {
                Customer = customer,
                CustomerId = customer.Id,
                CustomerRole = guest,
                CustomerRoleId = guest.Id
            });

            customer.IsRegistered().ShouldBeFalse();
            CustomerRole registred = new CustomerRole
            {
                Active = true,
                Name = "Registered",
                SystemName = SystemCustomerRoleNames.Registered
            };
            customer.CustomerRoles.Add(
                new CustomerCustomerRole
                {
                    Customer = customer,
                    CustomerId = customer.Id,
                    CustomerRole = registred,
                    CustomerRoleId= registred.Id
                });
            customer.IsRegistered().ShouldBeTrue();
        }

        [Fact]
        public void Can_add_address()
        {
            var customer = new Customer();
            var address = new Address { Id = 1 };

            customer.Addresses.Add(new CustomerAdresses()
            {
                Id=1,
                Address = address,
                Address_Id = address.Id,
                Customer = customer,
                CustomerId = customer.Id
            });

            customer.Addresses.Count.ShouldEqual(1);
            customer.Addresses.First().Id.ShouldEqual(1);
        }
        
        [Fact]
        public void Can_remove_address_assigned_as_billing_address()
        {
            var customer = new Customer();
            var address = new Address { Id = 1 };

            customer.Addresses.Add(new CustomerAdresses() {
                Id=1,
                Address =address,
                Address_Id =address.Id,
                Customer = customer,
                CustomerId =customer.Id });
            /*
            customer.BillingAddress  = address;

            customer.BillingAddress.ShouldBeTheSameAs(customer.Addresses.First());

            customer.RemoveAddress(address);
            customer.Addresses.Count.ShouldEqual(0);
            customer.BillingAddress.ShouldBeNull();*/
        }

        [Fact]
        public void Can_add_rewardPointsHistoryEntry()
        {
            //TODO temporary disabled until we can inject (not resolve using DI) "RewardPointsSettings" into "LimitPerStore" method of CustomerExtensions

            //var customer = new Customer();
            //customer.AddRewardPointsHistoryEntry(1, 0, "Points for registration");

            //customer.RewardPointsHistory.Count.ShouldEqual(1);
            //customer.RewardPointsHistory.First().Points.ShouldEqual(1);
        }

        [Fact]
        public void Can_get_rewardPointsHistoryBalance()
        {
            //TODO temporary disabled until we can inject (not resolve using DI) "RewardPointsSettings" into "LimitPerStore" method of CustomerExtensions

            //var customer = new Customer();
            //customer.AddRewardPointsHistoryEntry(1, 0, "Points for registration");

            //customer.GetRewardPointsBalance(0).ShouldEqual(1);
        }
    }
}
