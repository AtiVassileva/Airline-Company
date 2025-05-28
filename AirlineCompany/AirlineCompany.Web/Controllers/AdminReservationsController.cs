using AirlineCompany.Services.Contracts;
using AirlineCompany.Web.Infrastructure;
using AirlineCompany.Web.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AirlineCompany.Web.Controllers
{
    public class AdminReservationsController : Controller
    {
        private readonly IReservationService _reservationService;
        private readonly IMapper _mapper;

        public AdminReservationsController(IReservationService reservationService, IMapper mapper)
        {
            _reservationService = reservationService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var reservations = await _reservationService.GetAllAsync();
            var reservationsModels = _mapper.Map<List<ReservationListViewModel>>(reservations);

            return View(reservationsModels);
        }
    }
}