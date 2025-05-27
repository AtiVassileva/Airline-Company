using AirlineCompany.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static AirlineCompany.Web.Common.CommonConstants;

namespace AirlineCompany.Web.Controllers
{
    [Authorize(Roles = AdministratorRoleName)]
    public class ActivityLogsController : Controller
    {
        private readonly IActivityLogService _activityLogService;

        public ActivityLogsController(IActivityLogService activityLogService)
        {
            _activityLogService = activityLogService;
        }

        public async Task<IActionResult> Index()
        {
            var logs = await _activityLogService.GetAllAsync();
            return View(logs);
        }
    }
}