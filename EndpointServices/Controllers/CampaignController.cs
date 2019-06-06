using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Entities;
using DAL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using DAL.Interfaces.Services;
using DAL.ViewModels.Search;
using DAL.ViewModels.Campaigns;

namespace EndpointServices.Controllers
{
    [ApiController]
    public class CampaignController : Controller
    {
        ICampaignService service;

        public CampaignController(ICampaignService service)
        {
            this.service = service;
        }

        [Route("api/test-campaing")]
        public async Task<IActionResult> Index()
        {

            Campaign c = new Campaign();
            c.Name = "Campaign";
            c.StartDate = DateTime.Now;
            c.EndDate = DateTime.Now.AddDays(5);
            c.IsActiveRegistration = true;

            await this.service.Create(c);

            return Ok();
        }

        [HttpPost]
        [Route("api/campaign/create")]
        public async Task<IActionResult> Store(CampaignViewModel campaign)
        {
            Campaign c = new Campaign();
            c.Name = campaign.Name;
            c.StartDate = Convert.ToDateTime(campaign.StartDate);
            c.EndDate = Convert.ToDateTime(campaign.EndDate);
            c.IsActiveRegistration = campaign.IsActiveRegistration;

            var result = await this.service.Create(c);

            //if (!await this.service.Create(ClaimsHelper.GetUserId(this.User), l))
            //{
            //    return StatusCode(422);
            //}

            return Ok();
        }

        [Route("api/campaigns")]
        public async Task<IActionResult> List([FromQuery]string title, [FromQuery]int? page, [FromQuery]bool active)
        {
            CampaignSearchViewModel model = new CampaignSearchViewModel();
            model.Page = page;
            model.Title = title;
            model.Active = active;

            int p = model.Page != null ? model.Page.GetValueOrDefault() : 1;
            return Json(await this.service.GetCampaignPage(model));
        }

        [HttpGet]
        [Route("api/campaign/{id}")]
        public async Task<IActionResult> Find(int id)
        {            
            return Json(await this.service.GetCampaignPreviewPage(id));
        }

        [HttpPut]
        [Route("api/campaign")]
        public async Task<IActionResult> Update(Campaign campaign)
        {
            return Ok(await this.service.Update(campaign));
        }

        [HttpDelete]
        [Route("api/campaign/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (!await this.service.Delete(new Campaign() { Id = id }))
            {
                return StatusCode(403);
            }

            return Ok();
        }
    }
}