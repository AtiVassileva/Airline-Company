using AirlineCompany.Models;

namespace AirlineCompany.Services.Contracts
{
    public interface IActivityLogService
    {
        Task<IEnumerable<ActivityLog>> GetAllAsync();
    }
}