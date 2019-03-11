using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Interfaces;
using Microsoft.AspNetCore.Mvc;

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

        [Route("api/get-cities")]
        public async Task<IActionResult> GetCities()
        {
            return Json(await this.service.GetCities());
        }
    }
}