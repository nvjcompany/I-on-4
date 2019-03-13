using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using DAL.Interfaces;
using EndpointServices.Helpers;
using EndpointServices.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using DAL.Interfaces.Services;
using DAL.ViewModels.Auth;

namespace EndpointServices.Controllers
{
    [ApiController]
    public partial class LoginController : Controller
    {
        ILoginService service;

        public LoginController(ILoginService service)
        {
            this.service = service;
        }

        [HttpPost]
        [Route("api/login")]
        public async Task<IActionResult> Login([FromQuery(Name = "page")] LoginViewModel user)
        {
            var tupple = await this.service.Attempt(user.Email, user.Password);
            if (tupple.token == null)
            {
                return NotFound(tupple.message);
            }

            return Json(new LoginResponseViewModel(tupple.token, tupple.message));
        }

        [Authorize(Roles = "Administrator, Company, Student")]
        [HttpPost]
        [Route("api/login-test")]
        public IActionResult TestUserLogin()
        {
            //var userId = this.User.Claims.Where(x => x.Type == "UserId").First().Value;
            var userId = ClaimsHelper.GetUserId(this.User);
            var role = ClaimsHelper.GetUserRole(this.User);
            //role.Value
            var types = this.User.Claims.Select(x => new
            {
                Value = x.Value,
                name = x.Type
            }).ToList();
            return Json(types);
        }
    }
}