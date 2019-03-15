using DAL.Interfaces.Services;
using DAL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject.Factory
{
    public static class ListingServiceFactory
    {
        public static IListingService Create()
        {
            return new ListingService
            (
                 DatabaseFactory.Create(),
                 CampaignServiceFactory.Create(),
                 CompanyHelperFactory.Create()
             );
        }
    }
}
