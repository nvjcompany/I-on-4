using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Interfaces.Services;
using EndpointServices.Helpers;
using EndpointServices.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EndpointServices.Controllers
{
    [ApiController]
    public class ApplicationController : Controller
    {
        private IApplicationService service;

        public ApplicationController(IApplicationService service)
        {
            this.service = service;
        }

        [Authorize(Roles = "Student,Company")]
        [Route("api/applications")]
        public async Task<IActionResult> GetAll()
        {
            return Json(await this.service.GetApplications(ClaimsHelper.GetUserId(this.User), ClaimsHelper.GetUserRole(this.User)));
        }

        [HttpPost]
        [Authorize(Roles = "Company")]
        [Route("api/change-application-status")]
        public async Task<IActionResult> ChangeApplicationStatus(ApplicationStatusViewModel model)
        {
            return Json(new { success = await this.service.ChangeApplicationStatus(model.Status, ClaimsHelper.GetUserId(this.User), model.Id) });
        }
    }
}