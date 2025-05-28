using AirlineCompany.Models;
using System;
using AirlineCompany.Data;
using AirlineCompany.Services.Contracts;
using Microsoft.EntityFrameworkCore;

namespace AirlineCompany.Services
{
    public class ReservationService : IReservationService
    {
        private readonly AirFlyDbContext _dbContext;
        private readonly IStatusService _statusService;

        public ReservationService(AirFlyDbContext dbContext, IStatusService statusService)
        {
            _dbContext = dbContext;
            _statusService = statusService;
        }

        public async Task<bool> CreateReservationAsync(Reservation reservation, string ticketName)
        {
            var availability = await _dbContext.FlightSeatAvailabilities
                .FirstOrDefaultAsync(a => a.FlightId == reservation.FlightId);

            if (availability == null)
                return false;

            if (string.IsNullOrWhiteSpace(ticketName))
                return false;

            switch (ticketName)
            {
                case "Редовен": availability.EconomySeatsLeft--; break;
                case "Бизнес класа": availability.BusinessSeatsLeft--; break;
                case "Първа класа": availability.FirstClassSeatsLeft--; break;
            }

            _dbContext.Reservations.Add(reservation);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Reservation>> GetUserReservationsAsync(string userId)
        {
            return await _dbContext.Reservations
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