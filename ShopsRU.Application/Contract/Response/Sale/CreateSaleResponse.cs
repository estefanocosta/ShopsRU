using ShopsRU.Application.Contract.Response.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopsRU.Application.Contract.Response.Sale
{
    public  class CreateSaleResponse
    {
        public int SaleId { get; set; }
        public DateTime SaleDate { get; set; }

        public CreateSaleResponse MapToPaylod(ShopsRU.Domain.Entities.Sale  sale)
        {
            return  new CreateSaleResponse { SaleDate = sale.SaleDate, SaleId = sale.Id };
        }

    }
}
