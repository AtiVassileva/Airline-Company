using AirlineCompany.Models;

namespace AirlineCompany.Services.Contracts
{
    public interface IPlaneService
    {
        Task<IEnumerable<Plane>> GetAllAsync();
        Task<Plane?> GetByIdAsync(Guid id);
        Task CreateAsync(Plane plane);
        Task UpdateAsync(Plane plane);
        Task DeleteAsync(Guid id);
    }
}