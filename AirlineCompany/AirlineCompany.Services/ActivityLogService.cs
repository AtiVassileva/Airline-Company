using AirlineCompany.Models;
using AirlineCompany.Services.Contracts;
using AirlineCompany.Data;
using Microsoft.EntityFrameworkCore;

namespace AirlineCompany.Services
{
    public class ActivityLogService : IActivityLogService
    {
        private readonly AirFlyDbContext _dbContext;

        public ActivityLogService(AirFlyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<ActivityLog>> GetAllAsync()
            => await _dbContext.ActivityLogs
                .OrderByDescending(a => a.Timestamp)
                .ToListAsync();
    }
}