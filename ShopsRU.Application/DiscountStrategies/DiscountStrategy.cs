using ShopsRU.Application.Contract.Response.CustomerDiscount;
using ShopsRU.Domain.Entities;
using ShopsRU.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopsRU.Application.DiscountStrategies
{
    public class DiscountStrategy : IDiscountStrategy
    {
        public ApplyDiscountResponse ApplyDiscount(DiscountStratecyRules discountStratecyRules, Customer customer, decimal totalAmount)
        {
            ApplyDiscountResponse applyDiscountResponse = new ApplyDiscountResponse();
            bool isPercentageDiscountApplied = false;
            DateTime twoYearsAgo = DateTime.Now.AddYears(-2);
            if (customer != null)
            {
                if (customer.CustomerTypeId == (int)CustomerTypeEnum.Employee && !isPercentageDiscountApplied)
                {
                    applyDiscountResponse.DiscountAmount += totalAmount / 100 * discountStratecyRules.DiscountRate;
                    isPercentageDiscountApplied = true;
                }
                else if (customer.CustomerTypeId == (int)CustomerTypeEnum.Member && !isPercentageDiscountApplied)
                {
                    applyDiscountResponse.DiscountAmount += totalAmount / 100 * discountStratecyRules.DiscountRate;
                    isPercentageDiscountApplied = true;
                }
                else if (IsCustomerLoyal(customer.JoiningDate, discountStratecyRules.RuleJson.CustomerAgeMinYear) && customer.CustomerTypeId == (int)CustomerTypeEnum.LoyalCustomer && !isPercentageDiscountApplied)
                {
                    applyDiscountResponse.DiscountAmount += totalAmount / 100 * discountStratecyRules.DiscountRate;
                    isPercentageDiscountApplied = true;
                }
                int discountForEachHundredDollar = (int)totalAmount / discountStratecyRules.RuleJson.SubLimit;
                applyDiscountResponse.DiscountAmount += discountForEachHundredDollar * discountStratecyRules.RuleJson.SubLimitApplyDiscountAmount;
                applyDiscountResponse.NetAmount = totalAmount - applyDiscountResponse.DiscountAmount;
            }
            return applyDiscountResponse;
        }
        private bool IsCustomerLoyal(DateTime joiningDate, int customerAgeYear)
        {
            DateTime currentDate = DateTime.Now;
            TimeSpan customerAge = currentDate - joiningDate;
            return customerAge.TotalDays >= 365 * customerAgeYear;
        }
    }
}
