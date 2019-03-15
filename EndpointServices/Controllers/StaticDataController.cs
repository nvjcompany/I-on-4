using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using DAL.Interfaces.Services;

namespace EndpointServices.Controllers
{
    [ApiController]
    public class StaticDataController : Controller
    {
        private IStaticDataService service;

        public StaticDataController(IStaticDataService service)
        {
            this.service = service;
        }

        [HttpGet]
        [Route("api/get-cities")]
        public async Task<IActionResult> GetCities()
        {
            var result = await this.service.GetCities();
            return Json(result);
        }
    }
}