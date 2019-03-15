using DAL.Interfaces.Services;
using DAL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject.Factory
{
    public static class CampaignServiceFactory
    {
        public static ICampaignService Create()
        {
            return new CampaignService(DatabaseFactory.Create());
        }
    }
}
