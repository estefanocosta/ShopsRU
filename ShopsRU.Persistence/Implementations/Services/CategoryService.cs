﻿using ShopsRU.Application.Contract.Request.Category;
using ShopsRU.Application.Contract.Response.Category;
using ShopsRU.Application.Interfaces.Repositories;
using ShopsRU.Application.Interfaces.Services;
using ShopsRU.Application.Interfaces.UnitOfWork;
using ShopsRU.Application.Wrappers;
using ShopsRU.Infrastructure.Resources;

namespace ShopsRU.Persistence.Implementations.Services
{
    public class CategoryService : ICategoryService
    {
        ICategoryRepository _categoryRepository;
        IResourceService _resourceService;
        readonly IUnitOfWork _unitOfWork;
        public CategoryService(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork, IResourceService resourceService)
        {
            _categoryRepository = categoryRepository;
            _unitOfWork = unitOfWork;
            _resourceService = resourceService;
           
        }


        public async Task<ServiceDataResponse<CreateCategoryResponse>> CreateAsync(CreateCategoryRequest createCategoryRequest)
        {
            ServiceDataResponse<CreateCategoryResponse> serviceDataResponse = new ServiceDataResponse<CreateCategoryResponse>();

            var categoryCheck = await _categoryRepository.GetSingleAsync(x => x.Name.Trim().ToLower() == createCategoryRequest.Name.Trim().ToLower());
            if (categoryCheck != null)
            {
                serviceDataResponse.Success = false;
                serviceDataResponse.Message = _resourceService.GetResource("ALREADY_EXISTS");
                serviceDataResponse.StatusCode = 409;
                return serviceDataResponse;
            }
            int[] i = new int[1];
            i[0] = 1;
            i[1] = 2;
            i[2] = 2;
            var category = createCategoryRequest.MapToEntity();
            await _categoryRepository.AddAsync(category);

            var result = await _unitOfWork.CommitAsync();
            switch (result)
            {
                case true:
                    serviceDataResponse.Message = _resourceService.GetResource("OPERATION_SUCCESS");
                    serviceDataResponse.StatusCode = 200;
                    serviceDataResponse.Success = true;
                    serviceDataResponse.Paylod = createCategoryRequest.MapToPaylod(category);
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
