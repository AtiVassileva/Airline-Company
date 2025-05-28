using AirlineCompany.Data;
using AirlineCompany.Services.Contracts;
using Microsoft.EntityFrameworkCore;

namespace AirlineCompany.Services
{
    public class StatusService : IStatusService
    {
        private readonly AirFlyDbContext _dbContext;

        public StatusService(AirFlyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Guid> GetUpcomingStatusId()
        {
            var upcomingStatus = await _dbContext.Statuses.FirstAsync(s => s.Name.ToLower() == "предстояща");
            return upcomingStatus.Id;
        }

        public async Task<Guid> GetCancelledStatusId()
        {
            var cancelledStatus = await _dbContext.Statuses.FirstAsync(s => s.Name.ToLower() == "канселирана");
            return cancelledStatus.Id;
        }

        public async Task<Guid> GetCompletedStatusId()
        {
            var completedStatus = await _dbContext.Statuses.FirstAsync(s => s.Name.ToLower() == "приключена");
            return completedStatus.Id;
        }
    }
}