using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EndpointServices.Models;
using Microsoft.AspNetCore.Mvc;

namespace EndpointServices.Controllers
{
    [ApiController]
    public class TestController : Controller
    {
        [Route("api/test")]
        public IActionResult Index(TestViewModel model)
        {
            dynamic d = new { name = "Gosho" };

            return Json(d);
        }
    }
}