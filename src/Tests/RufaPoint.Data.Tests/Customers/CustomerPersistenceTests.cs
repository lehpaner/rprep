using System.Linq;
using RufaPoint.Core.Domain.Customers;
using RufaPoint.Tests;
using Xunit;

namespace RufaPoint.Data.Tests.Customers
{

    public class CustomerPersistenceTests : PersistenceTest
    {
        [Fact]
        public void Can_save_and_load_customer()
        {
            var customer = this.GetTestCustomer();

            var fromDb = SaveAndLoadEntity(this.GetTestCustomer());
            fromDb.ShouldNotBeNull();
            fromDb.PropertiesShouldEqual(customer);
        }

        [Fact]
        public void Can_save_and_load_customer_with_customerRoles()
        {
            var customer = this.GetTestCustomer();
            var role = this.GetTestCustomerRole();
            customer.CustomerRoles.Add(
                new CustomerCustomerRole()
                {
                    Customer = customer,
                    CustomerId=customer.Id,
                    CustomerRole=role,
                    CustomerRoleId= role.Id
                }
                );

            var fromDb = SaveAndLoadEntity(customer);
            fromDb.ShouldNotBeNull();
            fromDb.PropertiesShouldEqual(this.GetTestCustomer());

            fromDb.CustomerRoles.ShouldNotBeNull();
            (fromDb.CustomerRoles.Count == 1).ShouldBeTrue();
            fromDb.CustomerRoles.First().CustomerRole.PropertiesShouldEqual(this.GetTestCustomerRole());
        }

        [Fact]
        public void Can_save_and_load_customer_with_externalAuthenticationRecord()
        {
            var customer = this.GetTestCustomer();
            customer.ExternalAuthenticationRecords.Add(this.GetTestExternalAuthenticationRecord());

            var fromDb = SaveAndLoadEntity(customer);
            fromDb.ShouldNotBeNull();
            fromDb.PropertiesShouldEqual(this.GetTestCustomer());

            fromDb.ExternalAuthenticationRecords.ShouldNotBeNull();
            (fromDb.ExternalAuthenticationRecords.Count == 1).ShouldBeTrue();
            fromDb.ExternalAuthenticationRecords.First().PropertiesShouldEqual(this.GetTestExternalAuthenticationRecord());
        }

        [Fact]
        public void Can_save_and_load_customer_with_address()
        {
            var customer = this.GetTestCustomer();
            var address = this.GetTestAddress();
            customer.Addresses.Add(new CustomerAdresses() {
                Customer = customer,
                CustomerId = customer.Id,
                Address = address,
                AddressId = address.Id
            });

            var fromDb = SaveAndLoadEntity(customer);
            fromDb.ShouldNotBeNull();
            fromDb.PropertiesShouldEqual(this.GetTestCustomer());

            fromDb.Addresses.Count.ShouldEqual(1);
            fromDb.Addresses.First().Address.PropertiesShouldEqual(this.GetTestAddress());
        }

        [Fact]
        public void Can_set_default_billing_and_shipping_address()
        {
            var customer = this.GetTestCustomer();

            var address = this.GetTestAddress();
            var address2 = this.GetTestAddress();
            
            customer.Addresses.Add(new CustomerAdresses()
            {
                Customer = customer,
                CustomerId = customer.Id,
                Address = address,
                AddressId = address.Id
            });
            customer.Addresses.Add(new CustomerAdresses()
            {
                Customer = customer,
                CustomerId = customer.Id,
                Address = address2,
                AddressId = address2.Id
            });
            customer.BillingAddress = address;
            customer.ShippingAddress = address2;

            var fromDb = SaveAndLoadEntity(customer);
            fromDb.ShouldNotBeNull();
            fromDb.PropertiesShouldEqual(this.GetTestCustomer());

            fromDb.Addresses.Count.ShouldEqual(2);

            fromDb.BillingAddress.PropertiesShouldEqual(this.GetTestAddress());
            fromDb.ShippingAddress.PropertiesShouldEqual(this.GetTestAddress());

            var addresses = fromDb.Addresses.ToList();

            fromDb.BillingAddress.ShouldBeTheSameAs(addresses[0]);
            fromDb.ShippingAddress.ShouldBeTheSameAs(addresses[1]);
        }

        [Fact]
        public void Can_remove_a_customer_address()
        {
            var customer = this.GetTestCustomer();
            var address = this.GetTestAddress();
            customer.Addresses.Add(new CustomerAdresses()
            {
                Customer = customer,
                CustomerId = customer.Id,
                Address = address,
                AddressId = address.Id
            });
            customer.BillingAddress = address;

            var fromDb = SaveAndLoadEntity(customer);
            fromDb.ShouldNotBeNull();
            fromDb.Addresses.Count.ShouldEqual(1);
            fromDb.BillingAddress.ShouldNotBeNull();

            fromDb.RemoveAddress(address);

            context.SaveChanges();

            fromDb.Addresses.Count.ShouldEqual(0);
            fromDb.BillingAddress.ShouldBeNull();
        }
        
        [Fact]
        public void Can_save_and_load_customer_with_shopping_cart()
        {
            var customer = this.GetTestCustomer();

            var shoppingCartItems = this.GetTestShoppingCartItem();
            shoppingCartItems.Product = this.GetTestProduct();

            var testShoppingCartItems = this.GetTestShoppingCartItem();
            testShoppingCartItems.Product = this.GetTestProduct();

            customer.ShoppingCartItems.Add(shoppingCartItems);

            var fromDb = SaveAndLoadEntity(customer);
            fromDb.ShouldNotBeNull();

            fromDb.ShoppingCartItems.ShouldNotBeNull();
            (fromDb.ShoppingCartItems.Count == 1).ShouldBeTrue();
            fromDb.ShoppingCartItems.First().PropertiesShouldEqual(testShoppingCartItems);
        }
    }
}
