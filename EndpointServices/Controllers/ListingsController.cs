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
using DAL.ViewModels.Search;

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

        [Authorize(Roles = "Company,Student")]
        [HttpGet]
        [Route("api/listings")]
        //public async Task<IActionResult> List([FromBody]PaginationViewModel model)
        public async Task<IActionResult> List([FromQuery]string title, [FromQuery]int? page, [FromQuery]int? cityId)
        {
            ListingSearchViewModel model = new ListingSearchViewModel();
            model.Page = page;
            model.Title = title;
            model.CityId = cityId;

            int p = model.Page != null ? model.Page.GetValueOrDefault() : 1;

            return Json(await this.service.GetListingPage(ClaimsHelper.GetUserId(this.User), model));
        }

        [Authorize(Roles = "Company,Student")]
        [HttpGet]
        [Route("api/listing/{id}")]
        public async Task<IActionResult> Find(int id)
        {
            var page = await this.service.GetListingPreviewPage(id);
            object o = new { Listing = page, Test = 123 };
            return Json(await this.service.GetListingPreviewPage(id));
        }

        [Authorize(Roles = "Company")]
        [HttpPost]
        [Route("api/listings")]
        public async Task<IActionResult> Store(ListingViewModel listing)
        {
            Listing l = new Listing();
            l.Title = listing.Title;
            l.RegisterTo = listing.RegisterTo;
            l.RegisterFrom = listing.RegisterFrom;
            l.Description = listing.Description;
            l.CityId = listing.CityId;

            var result = await this.service.Create(ClaimsHelper.GetUserId(this.User), l);

            //if (!await this.service.Create(ClaimsHelper.GetUserId(this.User), l))
            //{
            //    return StatusCode(422);
            //}

            return Ok();
        }

        [Authorize(Roles = "Company")]
        [HttpPut]
        [Route("api/listing")]
        public async Task<IActionResult> Update(Listing listing)
        {
            return Ok(await this.service.Update(ClaimsHelper.GetUserId(this.User), listing));
        }

        [Authorize(Roles = "Company")]
        [HttpDelete]
        [Route("api/listing/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (!await this.service.Delete(ClaimsHelper.GetUserId(this.User), new Listing() { Id = id }))
            {
                return StatusCode(403);
            }

            return Ok();
        }

        [Authorize(Roles = "Student")]
        [Route("api/apply/{id}")]
        [HttpPost]
        public async Task<IActionResult> Apply(int id)
        {
            if (!await this.service.Apply(ClaimsHelper.GetUserId(this.User), id))
            {
                return StatusCode(422);
            }


            return Ok(true);
        }
    }
}