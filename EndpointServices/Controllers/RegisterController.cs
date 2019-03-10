using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using DAL.Entities;
using EndpointServices.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace EndpointServices.Controllers
{
    [ApiController]
    public class RegisterController : Controller
    {
        IRegisterService service;

        public RegisterController(IRegisterService service)
        {
            this.service = service;
        }

        [HttpPost]
        [Route("api/register")]
        public async Task<IActionResult> Index(RegisterViewModel model)
        {
            var result = await this.service.Register(new User()
            {
                Name = model.Name,
                LastName = model.LastName,
                PasswordHash = new PasswordHasher()
                .HashPassword((model.Password)),
                Email = model.Email,
                UserName = model.Email
            }, model.IsCompany ? "Company" : "Student");

            if (result == "success")
            {
                return Ok();
            }
            else if (result == "existing-email")
            {
                return StatusCode(422);
            }
            else
            {
                throw new Exception("Database Error");
            }
        }
    }
}