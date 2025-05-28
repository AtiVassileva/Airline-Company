using AirlineCompany.Data;
using AirlineCompany.Models;
using AirlineCompany.Services.Contracts;
using Microsoft.EntityFrameworkCore;

namespace AirlineCompany.Services
{
    public class FlightService : IFlightService
    {
        private readonly AirFlyDbContext _context;

        public FlightService(AirFlyDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Flight>> GetAllAsync()
            => await _context.Flights
                .Include(f => f.Plane)
                .Include(f => f.DepartureDestination)
                .Include(f => f.ArrivalDestination)
                .Include(f => f.SeatAvailability)
                .OrderBy(f => f.DepartureTime)
                .ThenBy(f => f.ArrivalTime)
                .ThenBy(f => f.FlightNumber)
                .ToListAsync();

        public async Task<Flight?> GetByIdAsync(Guid id)
            => await _context.Flights
                .Include(f => f.SeatAvailability)
                .FirstOrDefaultAsync(f => f.Id == id);

        public async Task<IEnumerable<Flight>> SearchFlightsAsync(Guid departureId, Guid arrivalId) 
            => await _context.Flights
                .Include(f => f.DepartureDestination)
                .Include(f => f.ArrivalDestination)
                .Include(f => f.Plane)
                .Where(f => f.DepartureDestinationId == departureId && f.ArrivalDestinationId == arrivalId && f.DepartureTime > DateTime.Now)
                .ToListAsync();

        public async Task CreateAsync(Flight flight)
        {
            _context.Flights.Add(flight);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Flight flight)
        {
            _context.Flights.Update(flight);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var flight = await _context.Flights.FindAsync(id);
            if (flight != null)
            {
                _context.Flights.Remove(flight);
                await _context.SaveChangesAsync();
            }
        }
    }
}