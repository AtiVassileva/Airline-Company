using AirlineCompany.Models;

namespace AirlineCompany.Services.Contracts
{
    public interface ILuggageTypeService
    {
        Task<IEnumerable<LuggageType>> GetAllAsync();
    }
}