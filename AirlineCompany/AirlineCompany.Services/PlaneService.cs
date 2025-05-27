using AirlineCompany.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            => await _dbContext.Planes.ToListAsync();

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