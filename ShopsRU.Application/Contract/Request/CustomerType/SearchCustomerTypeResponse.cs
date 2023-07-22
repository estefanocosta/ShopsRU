using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopsRU.Application.Contract.Request.CustomerType
{
    public  class SearchCustomerTypeResponse
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
