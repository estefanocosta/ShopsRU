using ShopsRU.Application.Contract.Response.CustomerDiscount;
using ShopsRU.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopsRU.Application.DiscountStrategies
{
    public  interface IDiscountStrategy
    {
        public ApplyDiscountResponse ApplyDiscount(DiscountStratecyRules discountStratecyRules, Customer customer,decimal amount);
    }
}
