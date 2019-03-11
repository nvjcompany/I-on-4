using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Entities;
using DAL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EndpointServices.Controllers
{
    [ApiController]
    public class ListingsController : Controller
    {
        private IListingService service;

        public ListingsController(IListingService service)
        {
            this.service = service;
        }


        [Route("api/test-listing")]
        public async Task<IActionResult> Store()
        {

            Listing l = new Listing();
            l.CompanyId = 1;
            l.Title = "Test";
            l.RegisterFrom = DateTime.Now;
            l.RegisterTo = DateTime.Now;
            l.Description = "Description";
            l.CampaignId = 1;
            await this.service.Create(l);
            return Ok();
        }
    }
}