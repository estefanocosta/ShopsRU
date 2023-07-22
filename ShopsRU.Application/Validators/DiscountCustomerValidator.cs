using FluentValidation;
using ShopsRU.Application.Contract.Request.CustomerDiscount;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopsRU.Application.Validators
{
    public class DiscountCustomerValidator : AbstractValidator<CreateCustomerDiscountRequest>
    {
        public DiscountCustomerValidator()
        {
            RuleFor(discountCustomer => discountCustomer.DiscountId)
                .GreaterThan(0).WithMessage("DiscountId must be a positive number.");

            RuleFor(discountCustomer => discountCustomer.CustomerTypeId)
                .GreaterThan(0).WithMessage("CustomerTypeId must be a positive number.");
        }
    }
}
