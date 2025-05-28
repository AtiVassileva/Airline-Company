using AirlineCompany.Services.Contracts;
using AirlineCompany.Web.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AirlineCompany.Web.Controllers
{
    public class ReportsController : Controller
    {
        private readonly IReportService _reportService;
        private readonly IFlightService _flightService;
        private readonly IMapper _mapper;

        public ReportsController(IReportService reportService, IMapper mapper, IFlightService flightService)
        {
            _reportService = reportService;
            _mapper = mapper;
            _flightService = flightService;
        }

        [HttpGet]
        public IActionResult Generate() => View(new ReportFilterModel());

        [HttpPost]
        public async Task<IActionResult> Generate(ReportFilterModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var flights = await _flightService.GetFlightsInDateRangeWithReservationsAsync(model.From, model.To);
            model.Results = _mapper.Map<List<FlightReportViewModel>>(flights);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> ExportCsv(ReportFilterModel model)
        {
            var flights = await  _flightService.GetFlightsInDateRangeWithReservationsAsync(model.From, model.To);
            var file = _reportService.ExportToCsvAsync(flights);
            return File(file, "text/csv", "flight_report.csv");
        }

        [HttpPost]
        public async Task<IActionResult> ExportExcel(ReportFilterModel model)
        {
            var flights = await _flightService.GetFlightsInDateRangeWithReservationsAsync(model.From, model.To);
            var file = _reportService.ExportToExcelAsync(flights);
            return File(file, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "flight_report.xlsx");
        }
    }
}