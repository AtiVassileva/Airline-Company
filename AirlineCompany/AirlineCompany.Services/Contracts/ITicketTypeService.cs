using AirlineCompany.Models;

namespace AirlineCompany.Services.Contracts
{
    public interface ITicketTypeService
    {
        Task<IEnumerable<TicketType>> GetAllAsync();
        Task<TicketType?> GetByIdAsync(Guid id);
    }
}