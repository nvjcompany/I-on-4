using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using DAL.Interfaces;
using IESAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace IESAPI.Controllers
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
        public IActionResult Login(LoginViewModel user)
        {
            var token = this.service.Attempt(user.Email, user.Password);
            if (token == null)
            {
                return NotFound();
            }

            return Ok(token);
        }
    }
}