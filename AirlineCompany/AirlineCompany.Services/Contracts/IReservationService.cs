using AirlineCompany.Models;

namespace AirlineCompany.Services.Contracts
{
    public interface IReservationService
    {
        Task<IEnumerable<Reservation>> GetAllAsync();
        Task<IEnumerable<Reservation>> GetUserReservationsAsync(string userId);
        Task<IEnumerable<Reservation>> GetFinishedReservationsAsync();
        Task<Reservation?> GetWithAllDetailsAsync(Guid id);
        Task<bool> CreateReservationAsync(Reservation reservation);
        Task<bool> CancelReservationAsync(Guid reservationId);
    }
}