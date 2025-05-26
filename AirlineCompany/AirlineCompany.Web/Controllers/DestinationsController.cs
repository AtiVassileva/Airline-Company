using AirlineCompany.Models;
using AirlineCompany.Services.Contracts;
using AirlineCompany.Web.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static AirlineCompany.Web.Common.CommonConstants;

namespace AirlineCompany.Web.Controllers
{
    public class DestinationsController : Controller
    {
        private readonly IDestinationService _destinationService;
        private readonly IMapper _mapper;

        public DestinationsController(IDestinationService destinationService, IMapper mapper)
        {
            _destinationService = destinationService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var destinations = await _destinationService.GetAllAsync();
            return View(destinations);
        }

        [Authorize(Roles = AdministratorRoleName)]
        public async Task<IActionResult> Update(Guid? id)
        {
            if (id == null) return View("Form", new DestinationFormModel());

            var entity = await _destinationService.GetByIdAsync(id.Value);
            if (entity == null) return NotFound();

            return View("Form", _mapper.Map<DestinationFormModel>(entity));
        }

        [HttpPost]
        [Authorize(Roles = AdministratorRoleName)]
        public async Task<IActionResult> Update(DestinationFormModel model)
        {
            if (!ModelState.IsValid) return View("Form", model);

            var entity = _mapper.Map<Destination>(model);

            if (model.Id == null || model.Id == Guid.Empty)
                await _destinationService.CreateAsync(entity);
            else
                await _destinationService.UpdateAsync(entity);

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [Authorize(Roles = AdministratorRoleName)]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _destinationService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}