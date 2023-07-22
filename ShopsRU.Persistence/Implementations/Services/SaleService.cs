using ShopsRU.Application.Contract.Request.Sale;
using ShopsRU.Application.Contract.Response.Sale;
using ShopsRU.Application.Interfaces.Repositories;
using ShopsRU.Application.Interfaces.Services;
using ShopsRU.Application.Interfaces.UnitOfWork;
using ShopsRU.Application.Wrappers;
using ShopsRU.Domain.Entities;
using ShopsRU.Infrastructure.Resources;

namespace ShopsRU.Persistence.Implementations.Services
{
    public class SaleService : ISaleService
    {
        readonly IProductRepository _productRepository;
        readonly ISaleRepository _saleRepository;
        readonly IResourceService _resourceService;
        readonly IUnitOfWork _unitOfWork;
        readonly ICustomerRepository _customerRepository;
        public SaleService(ISaleRepository saleRepository, IProductRepository productRepository, IUnitOfWork unitOfWork, ICustomerRepository customerRepository, IResourceService resourceService)
        {
            _saleRepository = saleRepository;
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
            _customerRepository = customerRepository;
            _resourceService = resourceService;
        }
        public async Task<ServiceDataResponse<CreateSaleResponse>> CreateAsync(CreateSaleRequest createSaleRequest)
        {
            ServiceDataResponse<CreateSaleResponse> serviceDataResponse = new ServiceDataResponse<CreateSaleResponse>();
            
            var customer = await _customerRepository.GetSingleAsync(x => x.Id == createSaleRequest.CustomerId);
            if (customer == null)
            {
                serviceDataResponse.Message = _resourceService.GetResource("RESOURCE_NOT_FOUND");
                serviceDataResponse.StatusCode = 404;

                serviceDataResponse.Success = false;
                return serviceDataResponse;
            }
            if (createSaleRequest.SaleDetailRequest.Count == 0)
            {
                serviceDataResponse.Message = _resourceService.GetResource("SALES_DETAIL_NOT_FOUND");
                serviceDataResponse.StatusCode = 404;
                serviceDataResponse.Success = false;
                return serviceDataResponse;
            }

            var sale = createSaleRequest.MapToEntity();
            foreach (var request in createSaleRequest.SaleDetailRequest)
            {
                var product = await _productRepository.GetSingleAsync(x => x.Id == request.ProductId);
                if (product != null)
                {
                    var detail = new SaleDetail();
                    detail.ProductId = product.Id;
                    detail.UnitPrice = product.Price;
                    detail.SaleId = sale.Id;
                    detail.Quantity = request.Quantity;
                    detail.TotalPrice = product.Price * request.Quantity;
                    sale.SaleDetails.Add(detail);
                }
            }
            sale.TotalAmount = sale.SaleDetails.Sum(x => x.TotalPrice);
            await _saleRepository.AddAsync(sale);
            var result = await _unitOfWork.CommitAsync();
            switch (result)
            {
                case true:
                    serviceDataResponse.Message = _resourceService.GetResource("OPERATION_SUCCESS");
                    serviceDataResponse.StatusCode = 200;
                    serviceDataResponse.Success = true;
                    serviceDataResponse.Paylod = createSaleRequest.MapToPaylod(sale);
                    break;

                case false:
                    serviceDataResponse.Message = _resourceService.GetResource("OPERATION_FAILED");
                    serviceDataResponse.StatusCode = 500;
                    serviceDataResponse.Success = false;
                    break;
            }
            return serviceDataResponse;
        }
    }
}
