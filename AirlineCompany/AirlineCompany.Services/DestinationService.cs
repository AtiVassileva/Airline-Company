using AirlineCompany.Data;
using AirlineCompany.Models;
using AirlineCompany.Services.Contracts;
using Microsoft.EntityFrameworkCore;

namespace AirlineCompany.Services
{
    public class DestinationService : IDestinationService
    {
        private readonly AirFlyDbContext _context;

        public DestinationService(AirFlyDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Destination>> GetAllAsync()
            => await _context.Destinations.ToListAsync();

        public async Task<Destination?> GetByIdAsync(Guid id)
            => await _context.Destinations.FindAsync(id);

        public async Task CreateAsync(Destination destination)
        {
            _context.Destinations.Add(destination);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Destination destination)
        {
            _context.Destinations.Update(destination);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await _context.Destinations.FindAsync(id);
            if (entity != null)
            {
                _context.Destinations.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}