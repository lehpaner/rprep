using System;
using RufaPoint.Core.Domain.Discounts;
using RufaPoint.Services.Discounts;
using RufaPoint.Tests;
using Xunit;

namespace RufaPoint.Services.Tests.Discounts
{
    public static class DiscountExtensions
    {
        public static decimal GetDiscountAmount(this Discount discount, decimal amount)
        {
            if (discount == null)
                throw new ArgumentNullException(nameof(discount));

            return discount.MapDiscount().GetDiscountAmount(amount);
        }
    }


    public class DiscountExtensionsTests : ServiceTest
    {
        [Fact]
        public void Can_calculate_discount_amount_percentage()
        {
            var discount = new Discount
            {
                UsePercentage = true,
                DiscountPercentage = 30
            };

            discount.GetDiscountAmount(100).ShouldEqual(30);

            discount.DiscountPercentage = 60;
            discount.GetDiscountAmount(200).ShouldEqual(120);
        }

        [Fact]
        public void Can_calculate_discount_amount_fixed()
        {
            var discount = new Discount
            {
                UsePercentage = false,
                DiscountAmount = 10
            };

            discount.GetDiscountAmount(100).ShouldEqual(10);

            discount.DiscountAmount = 20;
            discount.GetDiscountAmount(200).ShouldEqual(20);
        }

        [Fact]
        public void Maximum_discount_amount_is_used()
        {
            var discount = new Discount
            {
                UsePercentage = true,
                DiscountPercentage = 30,
                MaximumDiscountAmount = 3.4M
            };

            discount.GetDiscountAmount(100).ShouldEqual(3.4M);

            discount.DiscountPercentage = 60;
            discount.GetDiscountAmount(200).ShouldEqual(3.4M);
            discount.GetDiscountAmount(100).ShouldEqual(3.4M);

            discount.DiscountPercentage = 1;
            discount.GetDiscountAmount(200).ShouldEqual(2);
        }
    }
}
