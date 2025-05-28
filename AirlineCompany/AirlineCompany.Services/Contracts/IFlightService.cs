using AirlineCompany.Models;

namespace AirlineCompany.Services.Contracts
{
    public interface IFlightService
    {
        Task<IEnumerable<Flight>> GetAllAsync();
        Task<Flight?> GetByIdAsync(Guid id);
        Task<IEnumerable<Flight>> SearchFlightsAsync(Guid departureId, Guid arrivalId);
        Task CreateAsync(Flight flight);
        Task UpdateAsync(Flight flight);
        Task DeleteAsync(Guid id);
    }
}