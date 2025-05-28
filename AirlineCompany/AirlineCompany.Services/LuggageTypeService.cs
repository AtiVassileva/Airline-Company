using AirlineCompany.Data;
using AirlineCompany.Models;
using AirlineCompany.Services.Contracts;
using Microsoft.EntityFrameworkCore;

namespace AirlineCompany.Services
{
    public class LuggageTypeService : ILuggageTypeService
    {
        private readonly AirFlyDbContext _dbContext;

        public LuggageTypeService(AirFlyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<LuggageType>> GetAllAsync()
            => await _dbContext.LuggageTypes
                .ToListAsync();
    }
}