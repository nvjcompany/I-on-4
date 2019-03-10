using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using DAL.Interfaces;
using EndpointServices.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EndpointServices.Controllers
{
    [ApiController]
    public class LoginController : Controller
    {
        ILoginService service;

        public LoginController(ILoginService service)
        {
            this.service = service;
        }

        [HttpPost]
        [Route("api/login")]
        public async Task<IActionResult> Login(LoginViewModel user)
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
            var types = this.User.Claims.Select(x => new
            {
                Value = x.Value,
                name = x.Type
            }).ToList();
            return Json(types);
        }
    }
}