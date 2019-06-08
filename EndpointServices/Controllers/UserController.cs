using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Interfaces.Services;
using DAL.ViewModels.User;
using EndpointServices.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace EndpointServices.Controllers
{
    [ApiController]
    public class UserController : Controller
    {
        IUserService service;

        public UserController(IUserService service)
        {
            this.service = service;
        }

        [HttpGet]
        [Route("api/userFind")]
        public async Task<IActionResult> Find()
        {
            return Json(await this.service.Find(ClaimsHelper.GetUserId(User)));
        }

        [HttpPut]
        [Route("api/userUpdate")]
        public async Task<IActionResult> Update(UserViewModel model)
        {
            return Ok(await this.service.Update(model));
        }
    }
}