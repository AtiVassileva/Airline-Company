using AirlineCompany.Models;
using AirlineCompany.Data;
using AirlineCompany.Services.Contracts;
using Microsoft.EntityFrameworkCore;

namespace AirlineCompany.Services
{
    public class ReservationService : IReservationService
    {
        private readonly AirFlyDbContext _dbContext;
        private readonly IStatusService _statusService;
        private readonly ITicketTypeService _ticketTypeService;

        public ReservationService(AirFlyDbContext dbContext, IStatusService statusService, ITicketTypeService ticketTypeService)
        {
            _dbContext = dbContext;
            _statusService = statusService;
            _ticketTypeService = ticketTypeService;
        }

        public async Task<IEnumerable<Reservation>> GetAllAsync()
            => await _dbContext.Reservations
                .Include(r => r.Flight)
                .ThenInclude(f => f.DepartureDestination)
                .Include(r => r.Flight)
                .ThenInclude(f => f.ArrivalDestination)
                .Include(r => r.Passenger)
                .Include(r => r.TicketType)
                .Include(r => r.LuggageType)
                .Include(r => r.Status)
                .OrderByDescending(r => r.Flight.DepartureTime)
                .ToListAsync();

        public async Task<IEnumerable<Reservation>> GetUserReservationsAsync(string userId) 
            => await _dbContext.Reservations
                .Include(r => r.Flight)
                .ThenInclude(f => f.DepartureDestination)
                .Include(r => r.Flight)
                .ThenInclude(f => f.ArrivalDestination)
                .Include(r => r.Passenger)
                .Include(r => r.TicketType)
                .Include(r => r.LuggageType)
                .Include(r => r.Status)
                .Where(r => r.UserId == userId)
                .OrderByDescending(r => r.Flight.DepartureTime)
                .ToListAsync();

        public async Task<bool> CreateReservationAsync(Reservation reservation)
        {
            var availability = await _dbContext.FlightSeatAvailabilities
                .FirstOrDefaultAsync(a => a.FlightId == reservation.FlightId);

            if (availability == null)
                return false;

            var regularId = await _ticketTypeService.GetRegularTicketId();
            var businessClassId = await _ticketTypeService.GetBusinessTicketId();
            var firstClassId = await _ticketTypeService.GetFirstClassTicketId();

            switch (reservation.TicketId)
            {
                case var type when type == regularId:
                    if (availability.EconomySeatsLeft <= 0)
                        return false;
                    availability.EconomySeatsLeft--;
                    break;

                case var type when type == businessClassId:
                    if (availability.BusinessSeatsLeft <= 0)
                        return false;
                    availability.BusinessSeatsLeft--;
                    break;

                case var type when type == firstClassId:
                    if (availability.FirstClassSeatsLeft <= 0)
                        return false;
                    availability.FirstClassSeatsLeft--;
                    break;

                default:
                    return false;
            }

            _dbContext.Reservations.Add(reservation);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> CancelReservationAsync(Guid reservationId)
        {
            var reservation = await _dbContext.Reservations
                .FirstOrDefaultAsync(r => r.Id == reservationId);

            if (reservation == null) return false;

            var cancelledStatusId = await _statusService.GetCancelledStatusId();

            reservation.IsCancelled = true;
            reservation.StatusId = cancelledStatusId;

            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}