using ShopsRU.Domain.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopsRU.Domain.Entities
{
    public class Sale:BaseEntity
    {
        public Sale()
        {
            SaleDetails = new HashSet<SaleDetail>();
        }
        public int CustomerId { get; set; }
        public DateTime SaleDate { get; set; }
        public decimal TotalAmount { get; set; }
        public ICollection<SaleDetail> SaleDetails { get; set; }
        public int SellingUserId { get; set; }
        public ICollection<Invoice> Invoices { get; set; }
    }
}
