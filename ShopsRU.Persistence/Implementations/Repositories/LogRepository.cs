using ShopsRU.Application.Interfaces.Repositories;
using ShopsRU.Domain.Entities;
using ShopsRU.Persistence.Context.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopsRU.Persistence.Implementations.Repositories
{
    public class LogRepository : EfRepository<Log>, ILogRepository
    {
        public LogRepository(ShopsRUContext shopsRUContextContext) : base(shopsRUContextContext)
        {
        }
    }
}
