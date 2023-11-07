using ShopsRU.Application.Contract.Request.Category;
using ShopsRU.Application.Contract.Request.CustomerDiscount;
using ShopsRU.Application.Contract.Response.Category;
using ShopsRU.Application.Contract.Response.CustomerDiscount;
using ShopsRU.Application.Interfaces.Repositories;
using ShopsRU.Application.Interfaces.Services;
using ShopsRU.Application.Interfaces.UnitOfWork;
using ShopsRU.Application.Wrappers;
using ShopsRU.Domain.Entities;
using ShopsRU.Infrastructure.Resources;

namespace ShopsRU.Persistence.Implementations.Services
{
    public class CustomerDiscountService : ICustomerDiscountService
    {
        ICustomerDiscountRepository _customerDiscountRepository;
        ICustomerTypeRepository _customerTypeRepository;
        IUnitOfWork _unitOfWork;
        IResourceService _resourceService;
        public CustomerDiscountService(ICustomerDiscountRepository customerDiscountRepository, IUnitOfWork unitOfWork, ICustomerTypeRepository customerTypeRepository, IResourceService resourceService)
        {
            _customerDiscountRepository = customerDiscountRepository;
            _unitOfWork = unitOfWork;
            _customerTypeRepository = customerTypeRepository;
            _resourceService = resourceService;
        }
        public async Task<ServiceDataResponse<CustomerDiscountResponse>> CreateAsync(CreateCustomerDiscountRequest createCustomerDiscountRequest)
        {
            ServiceDataResponse<CustomerDiscountResponse> serviceDataResponse = new ServiceDataResponse<CustomerDiscountResponse>();

            var customerType = await _customerTypeRepository.GetByIdAsync(createCustomerDiscountRequest.CustomerTypeId);
            if (customerType == null)
            {
                return serviceDataResponse.CreateServiceResponse<CustomerDiscountResponse>(404, _resourceService, Domain.Enums.ResponseMessage.RESOURCE_NOT_FOUND);
            }
            var customerDiscountExists = await _customerDiscountRepository.GetSingleAsync(x => x.CustomerTypeId == createCustomerDiscountRequest.CustomerTypeId && x.IsDeleted == false);
            if (customerDiscountExists != null)
            {

                return serviceDataResponse.CreateServiceResponse<CustomerDiscountResponse>(409, _resourceService, Domain.Enums.ResponseMessage.ALREADY_EXISTS);
            }

            var customerDiscount = createCustomerDiscountRequest.MapToEntity();
            await _customerDiscountRepository.AddAsync(customerDiscount);
            var result = await _unitOfWork.CommitAsync();
            return serviceDataResponse.CreateServiceResponse<CustomerDiscountResponse>(result, createCustomerDiscountRequest.MapToPaylod(customerDiscount), _resourceService);
        }
    }
}
