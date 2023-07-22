using ShopsRU.Application.Contract.Request.Product;
using ShopsRU.Application.Contract.Response.Sale;
using ShopsRU.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopsRU.Application.Contract.Request.Sale
{
    public class CreateSaleRequest
    {
        public int CustomerId { get; set; }
        public DateTime SaleDate { get; set; }
        public int SellingUserId { get; set; }
        public List<SaleDetailRequest> SaleDetailRequest { get; set; }
        public CreateSaleResponse MapToPaylod(ShopsRU.Domain.Entities.Sale sale)
        {
            return new CreateSaleResponse { SaleDate = sale.SaleDate, SaleId = sale.Id };
        }


        public ShopsRU.Domain.Entities.Sale MapToEntity()
        {
            return new Domain.Entities.Sale()
            {
                CustomerId = this.CustomerId,
                SaleDate = DateTime.Now,
                SellingUserId = this.SellingUserId

            };
        }
    }
}
