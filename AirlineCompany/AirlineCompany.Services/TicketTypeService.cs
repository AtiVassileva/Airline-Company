using AirlineCompany.Data;
using AirlineCompany.Models;
using AirlineCompany.Services.Contracts;
using Microsoft.EntityFrameworkCore;

namespace AirlineCompany.Services
{
    public class TicketTypeService : ITicketTypeService
    {
        private readonly AirFlyDbContext _dbContext;

        public TicketTypeService(AirFlyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<TicketType>> GetAllAsync()
            => await _dbContext.TicketTypes
                .ToListAsync();

        public async Task<TicketType?> GetByIdAsync(Guid id)
            => await _dbContext.TicketTypes
                .FirstOrDefaultAsync(t => t.Id == id);
    }
}