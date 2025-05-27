using AirlineCompany.Services.Contracts;
using AirlineCompany.Data;
using AirlineCompany.Models;
using Microsoft.EntityFrameworkCore;

namespace AirlineCompany.Services
{
    public class PlaneService : IPlaneService
    {
        private readonly AirFlyDbContext _dbContext;

        public PlaneService(AirFlyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Plane>> GetAllAsync()
            => await _dbContext.Planes
                .OrderBy(p => p.Model)
                .ThenByDescending(p => p.EconomySeats)
                .ThenByDescending(p => p.BusinessSeats)
                .ThenByDescending(p => p.FirstClassSeats)
                .ToListAsync();

        public async Task<Plane?> GetByIdAsync(Guid id)
            => await _dbContext.Planes.FindAsync(id);

        public async Task CreateAsync(Plane plane)
        {
            _dbContext.Planes.Add(plane);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Plane plane)
        {
            _dbContext.Planes.Update(plane);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var plane = await GetByIdAsync(id);
            if (plane is null) return;

            _dbContext.Planes.Remove(plane);
            await _dbContext.SaveChangesAsync();
        }
    }
}