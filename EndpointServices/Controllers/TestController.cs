using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace EndpointServices.Controllers
{
    [ApiController]
    public class TestController : Controller
    {
        [Route("api/test")]
        public IActionResult Index()
        {
            string test = "test";
            return Json(test);
        }
    }
}