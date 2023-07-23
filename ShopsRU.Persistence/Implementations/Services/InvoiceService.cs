using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ShopsRU.Application.Contract.Request.Invoice;
using ShopsRU.Application.Contract.Response.CustomerDiscount;
using ShopsRU.Application.Contract.Response.Invoice;
using ShopsRU.Application.DiscountStrategies;
using ShopsRU.Application.Interfaces.Repositories;
using ShopsRU.Application.Interfaces.Services;
using ShopsRU.Application.Interfaces.UnitOfWork;
using ShopsRU.Application.Wrappers;
using ShopsRU.Domain.Entities;
using ShopsRU.Infrastructure.Resources;

namespace ShopsRU.Persistence.Implementations.Services
{
    public class InvoiceService : IInvoiceService
    {

        readonly ICustomerDiscountRepository _customerDiscountRepository;
        readonly ISaleRepository _saleRepository;
        readonly ISaleDetailRepository _saleDetailRepository;
        readonly IUnitOfWork _unitOfWork;
        readonly ICustomerRepository _customerRepository;
        readonly IInvoiceRepository _invoiceRepository;
        readonly IResourceService _resourceService;
        IDiscountStrategy _discountStrategy;
        public InvoiceService(IResourceService resourceService, ISaleRepository saleRepository, IUnitOfWork unitOfWork, ICustomerRepository customerRepository, IInvoiceRepository invoiceRepository, ISaleDetailRepository saleDetailRepository, IDiscountStrategy discountStrategy, ICustomerDiscountRepository customerDiscountRepository)
        {
            _invoiceRepository = invoiceRepository;
            _saleRepository = saleRepository;
            _unitOfWork = unitOfWork;
            _customerRepository = customerRepository;
            _saleDetailRepository = saleDetailRepository;
            _discountStrategy = discountStrategy;
            _customerDiscountRepository = customerDiscountRepository;
            _resourceService = resourceService;

        }
        public async Task<ServiceDataResponse<CreateInvoiceResponse>> CreateAsync(CreateInvoiceRequest createInvoiceRequest)
        {
            ServiceDataResponse<CreateInvoiceResponse> serviceDataResponse = new ServiceDataResponse<CreateInvoiceResponse>();
            var sale = await _saleRepository.GetByIdAsync(createInvoiceRequest.SaleId);
            if (sale == null)
            {
                serviceDataResponse.Message = _resourceService.GetResource("RESOURCE_NOT_FOUND");
                serviceDataResponse.StatusCode = 404;
                serviceDataResponse.Success = false;
                return serviceDataResponse;
            }
            var customer = await _customerRepository.GetByIdAsync(sale.CustomerId);
            if (customer == null)
            {
                serviceDataResponse.Message = _resourceService.GetResource("RESOURCE_NOT_FOUND");
                serviceDataResponse.StatusCode = 404;
                serviceDataResponse.Success = false;
                return serviceDataResponse;
            }



            var discountApplied = await ApplyDiscount(customer, sale.Id);
            if (!discountApplied.Success)
            {
                serviceDataResponse.Success = discountApplied.Success;
                serviceDataResponse.Message = discountApplied.Message;
                serviceDataResponse.StatusCode = discountApplied.StatusCode;
                return serviceDataResponse;
            }
            else
            {

                var invoice = createInvoiceRequest.MapToEntity(discountApplied.Paylod, customer.Id, sale.Id);
                await _invoiceRepository.AddAsync(invoice);
                var result = await _unitOfWork.CommitAsync();
                switch (result)
                {
                    case true:
                        serviceDataResponse.Message = _resourceService.GetResource("OPERATION_SUCCESS");
                        serviceDataResponse.StatusCode = 200;
                        serviceDataResponse.Success = true;
                        serviceDataResponse.Paylod = createInvoiceRequest.MapToPaylod(invoice);
                        break;
                    case false:
                        serviceDataResponse.Message = _resourceService.GetResource("OPERATION_FAILED");
                        serviceDataResponse.StatusCode = 500;
                        serviceDataResponse.Success = false;
                        break;
                }
            }

            return serviceDataResponse;
        }

        public async Task<ServiceDataResponse<GetSingleInvoiceResponse>> GetSingleAsync(int id)
        {
            ServiceDataResponse<GetSingleInvoiceResponse> serviceDataResponse = new ServiceDataResponse<GetSingleInvoiceResponse>();

            var invoice = await _invoiceRepository.GetByIdAsync(id);
            if (invoice == null)
            {
                serviceDataResponse.Message = _resourceService.GetResource("RESOURCE_NOT_FOUND");
                serviceDataResponse.StatusCode = 404;
                serviceDataResponse.Success = false;
                return serviceDataResponse;
            }
            GetSingleInvoiceResponse getSingleCustomerResponse = new GetSingleInvoiceResponse();
            getSingleCustomerResponse.CustomerName = string.Concat(invoice.Customer.FirstName, " ", invoice.Customer.LastName);
            getSingleCustomerResponse.DiscountAmount = invoice.DiscountAmount;
            getSingleCustomerResponse.NetAmount = invoice.NetAmount;
            getSingleCustomerResponse.TotalAmount = invoice.TotalAmount;
            getSingleCustomerResponse.SaleDate = invoice.Sale.SaleDate;
            getSingleCustomerResponse.SaleNo = invoice.Sale.Id;
            getSingleCustomerResponse.InvoiceDate = invoice.InvoiceDate;
            getSingleCustomerResponse.InvoiceId = invoice.Id;
            getSingleCustomerResponse.BillingUserId = invoice.BillingUserId;
            serviceDataResponse.Paylod = getSingleCustomerResponse;
            serviceDataResponse.Success = true;
            serviceDataResponse.Message = _resourceService.GetResource("DATA_RETRIEVED_SUCCESSFULLY");
            serviceDataResponse.StatusCode = 200;
            return serviceDataResponse;
        }
        public async Task<ServiceDataResponse<ApplyDiscountResponse>> ApplyDiscount(Customer customer, int saleId)
        {

            ServiceDataResponse<ApplyDiscountResponse> serviceDataResponse = new ServiceDataResponse<ApplyDiscountResponse>();

            var invoiceExists = await _invoiceRepository.GetSingleAsync(x => x.SaleId == saleId);
            if (invoiceExists != null)
            {
                serviceDataResponse.Success = false;
                serviceDataResponse.Message = _resourceService.GetResource("ALREADY_EXISTS");
                serviceDataResponse.Paylod = null;
                serviceDataResponse.StatusCode = 424;
                return serviceDataResponse;

            }
            var customerDiscount = await _customerDiscountRepository.GetAll().Include(x => x.Discounts).FirstOrDefaultAsync(x => x.CustomerTypeId == customer.CustomerTypeId);

            var discountStrategyRequest = new DiscountStrategyRules();
            discountStrategyRequest.CustomerTypeId = customerDiscount.CustomerTypeId;
            discountStrategyRequest.DiscountRate = customerDiscount.Discounts.DiscountRate;
            discountStrategyRequest.DiscountType = customerDiscount.Discounts.DiscountType;

            var ruleJson = JsonConvert.DeserializeObject<RuleJson>(customerDiscount.RuleJson);
            discountStrategyRequest.RuleJson = new RuleJson() { CustomerAgeYear = ruleJson.CustomerAgeYear, ExcludeCategories = ruleJson.ExcludeCategories, FixedAmount = ruleJson.FixedAmount, FixedDiscountAmount = ruleJson.FixedDiscountAmount, LoyalCustomerDiscountRate = ruleJson.LoyalCustomerDiscountRate, LoyalCustomerPriority = ruleJson.LoyalCustomerPriority };

            var details = await _saleDetailRepository.GetAll(x => x.SaleId == saleId).Include(x => x.Product).ToListAsync();

            var amountToBeDiscounted = details.Where(x => !ruleJson.ExcludeCategories.Contains(x.Product.CategoryId)).Sum(x => x.TotalPrice);
            var amountNotBeDiscounted = details.Where(x => ruleJson.ExcludeCategories.Contains(x.Product.CategoryId)).Sum(x => x.TotalPrice);

            serviceDataResponse.Success = true;
            serviceDataResponse.Paylod = _discountStrategy.ApplyDiscount(discountStrategyRequest, customer, amountToBeDiscounted);
            serviceDataResponse.Paylod.TotalAmount = amountToBeDiscounted + amountNotBeDiscounted;
            serviceDataResponse.StatusCode = 200;
            return serviceDataResponse;
        }
    }
}
