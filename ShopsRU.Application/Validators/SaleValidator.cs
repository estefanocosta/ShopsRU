using FluentValidation;
using ShopsRU.Application.Contract.Request.Sale;
using ShopsRU.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopsRU.Application.Validators
{
    public class SaleValidator : AbstractValidator<CreateSaleRequest>
    {
        public SaleValidator()
        {
            RuleFor(sale => sale.CustomerId)
                .GreaterThan(0).WithMessage("CustomerId must be a positive number.");

            RuleFor(sale => sale.SaleDate)
                .NotEmpty().WithMessage("SaleDate cannot be empty.");



            RuleFor(sale => sale.SellingUserId)
                .GreaterThan(0).WithMessage("SellingUserId must be a positive number.");
        }
    }
}
