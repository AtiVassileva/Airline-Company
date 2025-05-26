using Microsoft.AspNetCore.Identity;

namespace AirlineCompany.Services.Contracts
{
    public interface IUserService
    {
        Task<List<IdentityUser>> GetAllAsync();
        Task<IdentityUser?> GetByIdAsync(string id);
        Task<bool> DeleteAsync(string id);
        Task<bool> MakeAdminAsync(string id, string adminRoleName);
    }
}