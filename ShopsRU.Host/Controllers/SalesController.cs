using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopsRU.Application.Contract.Request.Product;
using ShopsRU.Application.Contract.Request.Sale;
using ShopsRU.Application.Interfaces.Services;
using ShopsRU.Persistence.Implementations.Services;

namespace ShopsRU.Host.Controllers
{
    [Route("api/")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        ISaleService _saleService;
        public SalesController(ISaleService saleService)
        {
            _saleService = saleService;
        }
        [HttpPost]
        [Route("sale")]
        public async Task<IActionResult> CreateAsync(CreateSaleRequest createSaleRequest)
        {
            var response = await _saleService.CreateAsync(createSaleRequest);
            return Ok(response);
        }
    }
}
