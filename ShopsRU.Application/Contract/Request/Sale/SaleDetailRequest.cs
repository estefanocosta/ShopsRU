﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopsRU.Application.Contract.Request.Sale
{
    public  class SaleDetailRequest
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
