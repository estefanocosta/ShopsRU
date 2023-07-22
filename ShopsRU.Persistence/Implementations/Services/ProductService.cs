using FluentValidation;
using ShopsRU.Application.Contract.Request.Product;
using ShopsRU.Application.Contract.Response.Product;
using ShopsRU.Application.Interfaces.Repositories;
using ShopsRU.Application.Interfaces.Services;
using ShopsRU.Application.Interfaces.UnitOfWork;
using ShopsRU.Application.Validators;
using ShopsRU.Application.Wrappers;
using ShopsRU.Infrastructure.Resources;

namespace ShopsRU.Persistence.Implementations.Services
{
    public class ProductService : IProductService
    {

        readonly IProductRepository _productRepository;
        readonly IUnitOfWork _unitOfWork;
        readonly IResourceService _resourceService;
    
        public ProductService(IProductRepository productRepository, IUnitOfWork unitOfWork, IResourceService resourceService)
        {
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
            _resourceService = resourceService;
        }
        public async Task<ServiceDataResponse<CreateProductResponse>> CreateAsync(CreateProductRequest createProductRequest)
        {
            ServiceDataResponse<CreateProductResponse> serviceDataResponse = new ServiceDataResponse<CreateProductResponse>();
 
            var prooductCheck = await _productRepository.GetSingleAsync(x => x.Name.Trim().ToLower() == createProductRequest.Name.Trim().ToLower());
            if (prooductCheck != null)
            {
                serviceDataResponse.Success = false;
                serviceDataResponse.Message = _resourceService.GetResource("ALREADY_EXISTS");
                serviceDataResponse.StatusCode = 409;
                return serviceDataResponse;
            }
            var product = createProductRequest.MapToEntity();
            await _productRepository.AddAsync(product);
            var result = await _unitOfWork.CommitAsync();
            switch (result)
            {
                case true:
                    serviceDataResponse.Message = _resourceService.GetResource("OPERATION_SUCCESS");
                    serviceDataResponse.StatusCode = 200;
                    serviceDataResponse.Success = true;
                    serviceDataResponse.Paylod = createProductRequest.MapToPaylod(product);
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
