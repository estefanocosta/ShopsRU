using Moq;
using ShopsRU.Application.Contract.Request.Category;
using ShopsRU.Application.Contract.Response.Category;
using ShopsRU.Application.Interfaces.Repositories;
using ShopsRU.Application.Interfaces.Services;
using ShopsRU.Application.Interfaces.UnitOfWork;
using ShopsRU.Application.Wrappers;
using ShopsRU.Domain.Entities;
using ShopsRU.Infrastructure.Resources;
using ShopsRU.Persistence.Implementations.UnitOfWork;

namespace ShopsRU.Tests.Application.Services
{
    public class CategoryServiceTests
    {

        readonly Mock<ICategoryService> _mockCategoryService;
        readonly Mock<ICategoryRepository> _mockCategoryRepository;
        readonly Mock<IResourceService> _mockResourceService;
        public CategoryServiceTests()
        {
            _mockCategoryService = new Mock<ICategoryService>();
            _mockCategoryRepository = new Mock<ICategoryRepository>();
            _mockResourceService = new Mock<IResourceService>();
        }


        [Fact]
        public async void CreateCategory_ReturnsCategory_WhenSuccess()
        {
            var createCategoryRequest = new CreateCategoryRequest { Name = "Test Category" };

            _mockCategoryRepository.Setup(repo => repo.GetSingleAsync(x => x.Name == createCategoryRequest.Name, true)).ReturnsAsync((Category)null);

            _mockCategoryService.Setup(x => x.CreateAsync(createCategoryRequest)).ReturnsAsync(new ServiceDataResponse<CreateCategoryResponse> { Success = true });
            var exists = await _mockCategoryRepository.Object.GetSingleAsync(x => x.Name == createCategoryRequest.Name);
            var result = await _mockCategoryService.Object.CreateAsync(createCategoryRequest);
            Assert.Equal(exists, null);
            Assert.True(result.Success);

        }

        [Fact]
        public async void CreateCategory_ReturnsCategory_WhenFail()
        {
            var createCategoryRequest = new CreateCategoryRequest { Name = "Test Category" };

            _mockCategoryRepository.Setup(repo => repo.GetSingleAsync(x => x.Name == createCategoryRequest.Name, true)).ReturnsAsync(new Category());

            _mockCategoryService.Setup(x => x.CreateAsync(createCategoryRequest)).ReturnsAsync(new ServiceDataResponse<CreateCategoryResponse> { Success = false });
            var exists = await _mockCategoryRepository.Object.GetSingleAsync(x => x.Name == createCategoryRequest.Name);
            var result = await _mockCategoryService.Object.CreateAsync(createCategoryRequest);
            Assert.NotNull(exists);
            Assert.False(result.Success);

        }

    }
}
