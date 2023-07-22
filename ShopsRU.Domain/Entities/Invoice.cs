using ShopsRU.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ShopsRU.Domain.Entities
{
    public class Invoice : BaseEntity
    {
        public int CustomerId { get; set; }
        public int SaleId { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal NetAmount { get; set; }
        public decimal DiscountAmount { get; set; }
        public DateTime InvoiceDate { get; set; }
        public int BillingUserId { get; set; }
        public Customer Customer { get; set; }

        public Sale Sale { get; set; }
    }
}
