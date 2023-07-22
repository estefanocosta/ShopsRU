﻿using ShopsRU.Application.Contract.Request.CustomerDiscount;
using ShopsRU.Application.Contract.Response.CustomerDiscount;
using ShopsRU.Application.Wrappers;

namespace ShopsRU.Application.Interfaces.Services
{
    public  interface ICustomerDiscountService
    {
        Task<ServiceDataResponse<CustomerDiscountResponse>> CreateAsync(CreateCustomerDiscountRequest  customerDiscountRequest);
    }
}
