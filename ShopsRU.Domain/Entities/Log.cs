using ShopsRU.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopsRU.Domain.Entities
{
    public  class Log:BaseEntity
    {
        public int UserID { get; set; }
        public string Message { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public string Method { get; set; }
        public string Trace { get; set; }
        public DateTime PostDate { get; set; }
        public int ErrorCode { get; set; }
    }
}
