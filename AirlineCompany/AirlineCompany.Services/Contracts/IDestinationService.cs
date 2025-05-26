using AirlineCompany.Models;

namespace AirlineCompany.Services.Contracts
{
    public interface IDestinationService
    {
        Task<IEnumerable<Destination>> GetAllAsync();
        Task<Destination?> GetByIdAsync(Guid id);
        Task CreateAsync(Destination destination);
        Task UpdateAsync(Destination destination);
        Task DeleteAsync(Guid id);
    }
}