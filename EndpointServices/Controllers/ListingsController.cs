using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Entities;
using DAL.Interfaces.Services;
using EndpointServices.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using DAL.ViewModels.Listings;
using EndpointServices.Models;

namespace EndpointServices.Controllers
{
    [ApiController]
    [Authorize(Roles = "Company")]
    public class ListingsController : Controller
    {
        private IListingService service;

        public ListingsController(IListingService service)
        {
            this.service = service;
        }

        [HttpGet]
        [Route("api/listings")]
        //public async Task<IActionResult> List([FromBody]PaginationViewModel model)
        public async Task<IActionResult> List(int? page)
        {
            //int page = model.Page != null ? model.Page.GetValueOrDefault() : 1;
            int p = page != null ? page.GetValueOrDefault() : 1;
            return Json(await this.service.GetListingPage(ClaimsHelper.GetUserId(this.User), p));
        }

        [HttpPost]
        [Route("api/listings")]
        public async Task<IActionResult> Store(ListingViewModel listing)
        {
            Listing l = new Listing();
            l.Title = listing.Title;
            l.RegisterTo = listing.RegisterTo;
            l.RegisterFrom = listing.RegisterFrom;
            l.Description = listing.Description;

            if (await this.service.Create(ClaimsHelper.GetUserId(this.User), l))
            {
                return StatusCode(422);
            }

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