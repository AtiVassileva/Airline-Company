using AirlineCompany.Models;
using AirlineCompany.Services.Contracts;
using AirlineCompany.Web.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static AirlineCompany.Web.Common.CommonConstants;

namespace AirlineCompany.Web.Controllers
{
    [Authorize(Roles = AdministratorRoleName)]
    public class PlanesController : Controller
    {
        private readonly IPlaneService _planeService;
        private readonly IMapper _mapper;

        public PlanesController(IPlaneService planeService, IMapper mapper)
        {
            _planeService = planeService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var planes = await _planeService.GetAllAsync();
            return View(planes);
        }

        public IActionResult Create()
        {
            return View("Form", new PlaneFormViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Create(PlaneFormViewModel model)
        {
            if (!ModelState.IsValid) return View("Form", model);

            var entity = _mapper.Map<Plane>(model);
            await _planeService.CreateAsync(entity);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var plane = await _planeService.GetByIdAsync(id);
            if (plane == null) return NotFound();

            var viewModel = _mapper.Map<PlaneFormViewModel>(plane);
            return View("Form", viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Guid id, PlaneFormViewModel model)
        {
            if (!ModelState.IsValid) return View("Form", model);

            var plane = await _planeService.GetByIdAsync(id);
            if (plane == null) return NotFound();

            _mapper.Map(model, plane);
            await _planeService.UpdateAsync(plane);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            await _planeService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}