using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopsRU.Application.Contract.Request.Category;
using ShopsRU.Application.Contract.Request.Customer;
using ShopsRU.Application.Contract.Request.CustomerType;
using ShopsRU.Application.Interfaces.Services;
using ShopsRU.Persistence.Implementations.Services;

namespace ShopsRU.Host.Controllers
{
    [Route("api/")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        ICustomerService _customerService;
        ICustomerTypeService _customerTypeService;
        public CustomersController(ICustomerService customerService, ICustomerTypeService customerTypeService)
        {
            _customerService = customerService;
            _customerTypeService = customerTypeService;
        }


        [HttpPost]
        [Route("customer")]
        public async Task<IActionResult> CreateAsync(CreateCustomerRequest createCustomerRequest)
        {

            var response = await _customerService.CreateAsync(createCustomerRequest);
            return Ok(response);
        }

        [HttpGet]
        [Route("customer-types")]
        public async Task<IActionResult> CreateAsync()
        {
            var response = await _customerTypeService.GetAllAsync();
            return Ok(response);
        }



        [HttpGet]
        [Route("customer/{id}")]
        public async Task<IActionResult> GetSingleAsync(int id)
        {
            var response = await _customerService.GetSingleAsync(id);
            return Ok(response);
        }
    }
}
