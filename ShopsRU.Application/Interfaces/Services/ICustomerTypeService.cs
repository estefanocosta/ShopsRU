using ShopsRU.Application.Contract.Request.CustomerType;

using ShopsRU.Application.Wrappers;

namespace ShopsRU.Application.Interfaces.Services
{
    public interface ICustomerTypeService
    {
        Task<ServiceDataResponse<List<SearchCustomerTypeResponse>>> GetAllAsync();
    }
}
