using ShopsRU.Application.Contract.Request.Log;

namespace ShopsRU.Application.Interfaces.Services
{
    public interface ILogService
    {
        Task CreateAsync(CreateLogRequest createLogRequest);
    }
}
