﻿using Newtonsoft.Json;
using ShopsRU.Application.Contract.Response.CustomerDiscount;
using ShopsRU.Application.DiscountStrategies;
using ShopsRU.Domain.Entities;

namespace ShopsRU.Application.Contract.Request.CustomerDiscount
{
    public class CreateCustomerDiscountRequest
    {
        public int DiscountId { get; set; }
        public int CustomerTypeId { get; set; }

        public RuleJson RuleJson { get; set; }


        public CustomerDiscountResponse MapToPaylod(ShopsRU.Domain.Entities.CustomerDiscount customerDiscount)
        {
            var ruleJson = JsonConvert.DeserializeObject<RuleJson>(customerDiscount.RuleJson);
            return new CustomerDiscountResponse { Id = customerDiscount.Id, DiscountId = customerDiscount.DiscountId, CustomerTypeId = customerDiscount.CustomerTypeId, RuleJson = new RuleJson() { ExcludeCategories = ruleJson.ExcludeCategories, SubLimit = ruleJson.SubLimit, SubLimitApplyDiscountAmount = ruleJson.SubLimitApplyDiscountAmount, CustomerAgeMinYear = ruleJson.CustomerAgeMinYear } };
        }


        public ShopsRU.Domain.Entities.CustomerDiscount MapToEntity()
        {
            return new Domain.Entities.CustomerDiscount()
            {
                CustomerTypeId = this.CustomerTypeId,
                DiscountId = this.DiscountId,
                RuleJson = Newtonsoft.Json.JsonConvert.SerializeObject(this.RuleJson)

            };
        }
    }

}