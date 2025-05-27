using AirlineCompany.Models;
using AirlineCompany.Services.Contracts;
using AirlineCompany.Web.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AirlineCompany.Web.Controllers
{
    public class FlightsController : Controller
    {
        private readonly IFlightService _flightService;
        private readonly IPlaneService _planeService;
        private readonly IDestinationService _destinationService;
        private readonly IMapper _mapper;

        public FlightsController(IFlightService flightService, IMapper mapper, IPlaneService planeService, IDestinationService destinationService)
        {
            _flightService = flightService;
            _mapper = mapper;
            _planeService = planeService;
            _destinationService = destinationService;
        }

        public async Task<IActionResult> Index()
        {
            var flights = await _flightService.GetAllAsync();
            var viewModel = _mapper.Map<IEnumerable<FlightViewModel>>(flights);
            return View(viewModel);
        }

        public async Task<IActionResult> Create()
            => await LoadForm(new FlightFormViewModel {DepartureTime = DateTime.Now, ArrivalTime = DateTime.Now});

        [HttpPost]
        public async Task<IActionResult> Create(FlightFormViewModel model)
        {
            if (!ModelState.IsValid)
                return await LoadForm(model);

            var entity = _mapper.Map<Flight>(model);
            
            var plane = (await _planeService.GetAllAsync()).First(p => p.Id == model.PlaneId);

            entity.SeatAvailability = new FlightSeatAvailability
            {
                EconomySeatsLeft = plane.EconomySeats,
                BusinessSeatsLeft = plane.BusinessSeats,
                FirstClassSeatsLeft = plane.FirstClassSeats
            };

            await _flightService.CreateAsync(entity);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var flight = await _flightService.GetByIdAsync(id);
            if (flight == null) return NotFound();

            var model = _mapper.Map<FlightFormViewModel>(flight);
            return await LoadForm(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Guid id, FlightFormViewModel model)
        {
            if (!ModelState.IsValid)
                return await LoadForm(model);

            var existingFlight = await _flightService.GetByIdAsync(id);
            if (existingFlight == null) return NotFound();

            _mapper.Map(model, existingFlight);

            await _flightService.UpdateAsync(existingFlight);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            await _flightService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        private async Task<IActionResult> LoadForm(FlightFormViewModel model)
        {
            model.Planes = (await _planeService.GetAllAsync())
                .Select(p => new SelectListItem { Text = p.Model, Value = p.Id.ToString() }).ToList();

            model.Destinations = (await _destinationService.GetAllAsync())
                .Select(d => new SelectListItem
                {
                    Text = $"{d.CityName} ({d.AirportName}) - {d.CountryName}",
                    Value = d.Id.ToString()
                }).ToList();

            return View("Form", model);
        }
    }
}