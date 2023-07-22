﻿using ShopsRU.Application.Contract.Request.Customer;
using ShopsRU.Application.Contract.Response.Customer;
using ShopsRU.Application.Interfaces.Repositories;
using ShopsRU.Application.Interfaces.Services;
using ShopsRU.Application.Interfaces.UnitOfWork;
using ShopsRU.Application.Wrappers;
using ShopsRU.Infrastructure.Resources;

namespace ShopsRU.Persistence.Implementations.Services
{
    public class CustomerService : ICustomerService
    {
        ICustomerRepository _customerRepository;
        IUnitOfWork _unitOfWork;
        IResourceService _resourceService;
        public CustomerService(ICustomerRepository customerRepository, IUnitOfWork unitOfWork, IResourceService resourceService)
        {
            _customerRepository = customerRepository;
            _unitOfWork = unitOfWork;
            _resourceService = resourceService;
        }
        public async Task<ServiceDataResponse<CreateCustomerResponse>> CreateAsync(CreateCustomerRequest createCustomerRequest)
        {
            ServiceDataResponse<CreateCustomerResponse> serviceDataResponse = new ServiceDataResponse<CreateCustomerResponse>();
            var customer = createCustomerRequest.MapToEntity();
            await _customerRepository.AddAsync(customer);
            var result = await _unitOfWork.CommitAsync();
            switch (result)
            {
                case true:
                    serviceDataResponse.Message = _resourceService.GetResource("OPERATION_SUCCESS");
                    serviceDataResponse.StatusCode = 200;
                    serviceDataResponse.Success = true;
                    serviceDataResponse.Paylod = createCustomerRequest.MapToPaylod(customer);
                    break;

                case false:
                    serviceDataResponse.Message = _resourceService.GetResource("OPERATION_FAILED");
                    serviceDataResponse.StatusCode = 500;
                    serviceDataResponse.Success = false;
                    break;
            }
            return serviceDataResponse;
        }

        public async Task<ServiceDataResponse<GetSingleCustomerResponse>> GetSingleAsync(int id)
        {
            ServiceDataResponse<GetSingleCustomerResponse> serviceDataResponse = new ServiceDataResponse<GetSingleCustomerResponse>();

            var customer = await _customerRepository.GetSingleAsync(x => x.Id == id);
            if (customer == null)
            {
                serviceDataResponse.Message = _resourceService.GetResource("RESOURCE_NOT_FOUND");
                serviceDataResponse.StatusCode = 404;
                serviceDataResponse.Success = false;
                return serviceDataResponse;
            }
            GetSingleCustomerResponse getSingleCustomerResponse = new GetSingleCustomerResponse();
            serviceDataResponse.Message = _resourceService.GetResource("DATA_RETRIEVED_SUCCESSFULLY");
            serviceDataResponse.StatusCode = 200;
            serviceDataResponse.Success = true;
            serviceDataResponse.Paylod = new GetSingleCustomerResponse { Id = customer.Id, FirstName = customer.FirstName, LastName = customer.LastName, JoiningDate = customer.JoiningDate, CustomerTypeId = customer.CustomerTypeId, CreatedOn = customer.CreatedOn };
            return serviceDataResponse;
        }
    }
}
