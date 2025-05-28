using AirlineCompany.Models;

namespace AirlineCompany.Services.Contracts
{
    public interface IReservationService
    {
        Task<bool> CreateReservationAsync(Reservation reservation, string ticketName);
        Task<IEnumerable<Reservation>> GetUserReservationsAsync(string userId);
        Task<bool> CancelReservationAsync(Guid reservationId);
    }
}