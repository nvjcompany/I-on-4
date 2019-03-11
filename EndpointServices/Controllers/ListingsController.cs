using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace EndpointServices.Controllers
{
    [ApiController]
    public class ListingsController : Controller
    {
        public async Task<IActionResult> Store()
        {
            return Ok();
        }
    }
}