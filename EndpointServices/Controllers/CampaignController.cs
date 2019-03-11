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
    }
}