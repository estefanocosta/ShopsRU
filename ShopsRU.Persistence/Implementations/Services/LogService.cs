using Microsoft.Extensions.DependencyInjection;
using ShopsRU.Application.Contract.Request.Log;
using ShopsRU.Application.Interfaces.Repositories;
using ShopsRU.Application.Interfaces.Services;
using ShopsRU.Application.Interfaces.UnitOfWork;
using ShopsRU.Persistence.Context.EntityFramework;
using ShopsRU.Persistence.Implementations.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopsRU.Persistence.Implementations.Services
{
    public class LogService : ILogService
    {
        ILogRepository _logRepository;
        IUnitOfWork _unitOfWork;
        public LogService(ILogRepository logRepository, IUnitOfWork unitOfWork)
        {
            _logRepository = logRepository;
            _unitOfWork = unitOfWork;
        }


        public async Task CreateAsync(CreateLogRequest createLogRequest)
        {
            var log = createLogRequest.MapToEntity();
            await _logRepository.AddAsync(log);
            await _unitOfWork.CommitAsync();
        }
    }
}
