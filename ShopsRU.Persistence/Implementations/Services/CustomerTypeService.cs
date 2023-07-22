using Microsoft.EntityFrameworkCore;
using ShopsRU.Application.Contract.Request.CustomerType;
using ShopsRU.Application.Interfaces.Repositories;
using ShopsRU.Application.Interfaces.Services;
using ShopsRU.Application.Wrappers;
using ShopsRU.Infrastructure.Resources;

namespace ShopsRU.Persistence.Implementations.Services
{
    public class CustomerTypeService : ICustomerTypeService
    {
        readonly ICustomerTypeRepository _customerTypeRepository;
        readonly IResourceService _resourceService;

        public CustomerTypeService(ICustomerTypeRepository customerTypeRepository, IResourceService resourceService)
        {
            _customerTypeRepository = customerTypeRepository;
            _resourceService = resourceService;
        }
        public async Task<ServiceDataResponse<List<SearchCustomerTypeResponse>>> GetAllAsync()
        {
            ServiceDataResponse<List<SearchCustomerTypeResponse>> serviceDataResponse = new ServiceDataResponse<List<SearchCustomerTypeResponse>>();
            var customerTypes = await _customerTypeRepository.GetAll(x => !x.IsDeleted).Select(x => new SearchCustomerTypeResponse()
            {
                Id = x.Id,
                Type = x.Type,
                CreatedOn = x.CreatedOn
            }).ToListAsync();
            serviceDataResponse.Paylod = customerTypes;
            serviceDataResponse.StatusCode = 200;
            serviceDataResponse.Success = true;
            serviceDataResponse.Message = _resourceService.GetResource("DATA_RETRIEVED_SUCCESSFULLY");
            return serviceDataResponse;
        }
    }
}
