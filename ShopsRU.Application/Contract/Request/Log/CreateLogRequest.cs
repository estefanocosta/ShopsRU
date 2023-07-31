using ShopsRU.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ShopsRU.Application.Contract.Request.Log
{
    public class CreateLogRequest
    {
        public int UserID { get; set; }
        public string Message { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public string Method { get; set; }
        public string Trace { get; set; }
        public DateTime PostDate { get; set; }
        public int ErrorCode { get; set; }
        public ShopsRU.Domain.Entities.Log MapToEntity()
        {
            return new Domain.Entities.Log()
            {
                Message = this.Message,
                Controller = this.Controller,
                Method = this.Method,
                PostDate = DateTime.Now,
                Action = this.Action,
                Trace = this.Trace,
                ErrorCode = this.ErrorCode,
                UserID = 5
            };
        }
    }
}
