using DAL.Interfaces.Services;
using DAL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject.Factory
{
    public static class StaticDataServiceFactory
    {
        public static IStaticDataService Create()
        {
            return new StaticDataService(DatabaseFactory.Create());
        }
    }
}
