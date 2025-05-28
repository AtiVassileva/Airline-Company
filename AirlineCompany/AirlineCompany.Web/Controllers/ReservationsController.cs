using AirlineCompany.Models;
using AirlineCompany.Services.Contracts;
using AirlineCompany.Web.Infrastructure;
using AirlineCompany.Web.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AirlineCompany.Web.Controllers
{
    [Authorize]
    public class ReservationsController : Controller
    {
        private readonly IReservationService _reservationService;
        private readonly IFlightService _flightService;
        private readonly IDestinationService _destinationService;
        private readonly ITicketTypeService _ticketTypeService;
        private readonly ILuggageTypeService _luggageTypeService;
        private readonly IStatusService _statusService;
        private readonly IBoardingPassService _boardingPassService;
        private readonly IMapper _mapper;

        public ReservationsController(IReservationService reservationService, IMapper mapper, IFlightService flightService, ITicketTypeService ticketTypeService, ILuggageTypeService luggageTypeService, IStatusService statusService, IDestinationService destinationService, IBoardingPassService boardingPassService)
        {
            _reservationService = reservationService;
            _mapper = mapper;
            _flightService = flightService;
            _ticketTypeService = ticketTypeService;
            _luggageTypeService = luggageTypeService;
            _statusService = statusService;
            _destinationService = destinationService;
            _boardingPassService = boardingPassService;
        }

        public async Task<IActionResult> Search()
        {
            var destinations = await GetDestinationsAsync();
            var model = new SearchFlightViewModel { Destinations = destinations };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Search(SearchFlightViewModel model)
        {
            var matchingFlights =
                await _flightService.SearchFlightsAsync(model.DepartureDestinationId, model.ArrivalDestinationId);

            var flightModels = _mapper.Map<List<FlightViewModel>>(matchingFlights);

            model.DepartureDestinationId = model.DepartureDestinationId;
            model.ArrivalDestinationId = model.ArrivalDestinationId;
            model.Destinations = await GetDestinationsAsync();
            model.Flights = flightModels;

            return View(model);
        }

        public async Task<IActionResult> Create(Guid flightId)
        {
            var flight = await _flightService.GetByIdAsync(flightId);
            if (flight == null) return NotFound();

            var vm = new ReservationFormModel
            {
                FlightId = flight.Id,
                TicketTypes = await GetTicketTypesAsync(),
                LuggageTypes = await GetLuggageTypesAsync()
            };

            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ReservationFormModel model)
        {
            if (!ModelState.IsValid)
            {
                model.TicketTypes = await GetTicketTypesAsync();
                model.LuggageTypes = await GetLuggageTypesAsync();
                return View(model);
            }

            var reservation = _mapper.Map<Reservation>(model);
            reservation.UserId = User.GetId()!;
            reservation.StatusId = await GetDefaultStatusIdAsync();

            var isReserved = await _reservationService.CreateReservationAsync(reservation);

            if (!isReserved)
            {
                TempData["Error"] = "Няма налични места за избраният от вас тип билет!";

                model.TicketTypes = await GetTicketTypesAsync();
                model.LuggageTypes = await GetLuggageTypesAsync();
                return View(model);
            }

            return RedirectToAction(nameof(Mine));
        }

        public async Task<IActionResult> Mine()
        {
            var userId = User.GetId()!;
            var reservations = await _reservationService.GetUserReservationsAsync(userId);
            var reservationsModels = _mapper.Map<List<ReservationListViewModel>>(reservations);

            return View(reservationsModels);
        }

        public async Task<IActionResult> DownloadBoardingPass(Guid id)
        {
            var reservation = await _reservationService.GetWithAllDetailsAsync(id);

            if (reservation == null || reservation.UserId != User.GetId())
            {
                return NotFound();
            }

            var pdfBytes = _boardingPassService.GeneratePdf(reservation);
            return File(pdfBytes, "application/pdf", $"boarding-pass-{reservation.Flight.FlightNumber}.pdf");
        }

        public async Task<IActionResult> Cancel(Guid id)
        {
            var success = await _reservationService.CancelReservationAsync(id);
            if (!success) return NotFound();

            return RedirectToAction(nameof(Mine));
        }

        private async Task<Guid> GetDefaultStatusIdAsync()
            => await _statusService.GetUpcomingStatusId();

        private async Task<List<SelectListItem>> GetTicketTypesAsync()
        {
            var ticketTypes = await _ticketTypeService.GetAllAsync();
            var selectList = ticketTypes.Select(t => new SelectListItem(t.Name, t.Id.ToString())).ToList();

            return selectList;
        }

        private async Task<List<SelectListItem>> GetLuggageTypesAsync()
        {
            var luggageTypes = await _luggageTypeService.GetAllAsync();
            var selectList = luggageTypes.Select(l => new SelectListItem(l.Name, l.Id.ToString())).ToList();

            return selectList;
        }

        private async Task<List<SelectListItem>> GetDestinationsAsync()
        {
            var destinations = await _destinationService.GetAllAsync();
            var selectList = destinations.Select(d => new SelectListItem
            {
                Text = string.Concat(d.CityName, " (", d.AirportName, ")", " - ", d.CountryName),
                Value = d.Id.ToString()
            }).ToList();

            return selectList;
        }
    }
}