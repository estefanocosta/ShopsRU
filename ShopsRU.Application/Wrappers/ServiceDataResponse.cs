using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopsRU.Application.Wrappers
{
    public class ServiceDataResponse<T> : ServiceResponse
    {
        public T Paylod { get; set; }
    }
}
