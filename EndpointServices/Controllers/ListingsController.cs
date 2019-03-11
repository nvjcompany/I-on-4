using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Entities;
using DAL.Interfaces;
using EndpointServices.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EndpointServices.Controllers
{
    [ApiController]
    [Authorize("Company")]
    public class ListingsController : Controller
    {
        private IListingService service;

        public ListingsController(IListingService service)
        {
            this.service = service;
        }

        [HttpPost]
        [Route("api/listing")]
        public async Task<IActionResult> Store(Listing listing)
        {

            //Listing l = new Listing();
            // l.CompanyId = 1;
            //l.Title = "Test";
            // l.RegisterFrom = DateTime.Now;
            //l.RegisterTo = DateTime.Now;
            //l.Description = "Description";
            //l.CampaignId = 1;
            await this.service.Create(ClaimsHelper.GetUserId(this.User), listing);
            return Ok();
        }

        [HttpPut]
        [Route("api/listing")]
        public async Task<IActionResult> Update(Listing listing)
        {
            await this.service.Update(ClaimsHelper.GetUserId(this.User), listing);
            return Ok();
        }

        [HttpDelete]
        [Route("api/listing")]
        public async Task<IActionResult> Delete(int listingId)
        {
            await this.service.Delete(new Listing() { Id = listingId });
            return Ok();
        }
    }
}