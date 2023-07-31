using Moq;
using ShopsRU.Application.Contract.Response.CustomerDiscount;
using ShopsRU.Application.DiscountStrategies;
using ShopsRU.Application.Interfaces.Services;
using ShopsRU.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ShopsRU.Tests.DiscountStrategies
{
    public class DiscountStrategyTests
    {
        private Mock<IDiscountStrategy> _discountStrategyMock;
        private Customer _customer;
        private decimal _totalAmount;
        private DiscountStrategyRules _rule;

        public DiscountStrategyTests()
        {
            _discountStrategyMock = new Mock<IDiscountStrategy>();
            _customer = new Customer();
            _totalAmount = 10000;
            _rule = new DiscountStrategyRules();
        }

        private void SetupCustomerAndRules(int customerTypeId, int discountRate)
        {
            _customer.CustomerTypeId = customerTypeId;
            _rule.CustomerTypeId = _customer.CustomerTypeId;
            _rule.DiscountRate = discountRate;
            _rule.RuleJson = new RuleJson()
            {
                FixedAmount = 100,
                FixedDiscountAmount = 5,
                LoyalCustomerPriority = false,
                CustomerAgeYear = 0,
                LoyalCustomerDiscountRate = 0,
                ExcludeCategories = new List<int> { 3 }
            };
        }

        private ApplyDiscountResponse GetResponse(decimal netAmount, decimal discountAmount)
        {
            var response = new ApplyDiscountResponse();
            response.NetAmount = netAmount;
            response.DiscountAmount = discountAmount;

            return response;
        }

        private void SetupMock(ApplyDiscountResponse response)
        {
            _discountStrategyMock.Setup(service => service.ApplyDiscount(_rule, _customer, _totalAmount)).Returns(response);
        }

        [Fact]
        public void ApplyDiscount_CustomerType_Employee()
        {
            // Arrange
            SetupCustomerAndRules(1, 30);
            var expectedResponse = GetResponse(7000, 3000);
            SetupMock(expectedResponse);

            // Act
            ApplyDiscountResponse result = _discountStrategyMock.Object.ApplyDiscount(_rule, _customer, _totalAmount);

            // Assert
            Assert.Equal(expectedResponse.NetAmount, result.NetAmount);
        }

        [Fact]
        public void ApplyDiscount_CustomerType_Member()
        {
            // Arrange
            SetupCustomerAndRules(2, 10);
            var expectedResponse = GetResponse(8000, 2000);
            SetupMock(expectedResponse);

            // Act
            ApplyDiscountResponse result = _discountStrategyMock.Object.ApplyDiscount(_rule, _customer, _totalAmount);

            // Assert
            Assert.Equal(expectedResponse.NetAmount, result.NetAmount);
        }

        [Fact]
        public void ApplyDiscount_CustomerType_Member_Priority_Loyal_Customer_True()
        {
            // Arrange
            SetupCustomerAndRules(2, 10);
            var expectedResponse = GetResponse(9500, 500);
            SetupMock(expectedResponse);

            // Act
            ApplyDiscountResponse result = _discountStrategyMock.Object.ApplyDiscount(_rule, _customer, _totalAmount);

            // Assert
            Assert.Equal(expectedResponse.NetAmount, result.NetAmount);
        }
    }
}
