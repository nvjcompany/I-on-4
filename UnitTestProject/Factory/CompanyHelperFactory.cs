using DAL.Helpers;
using DAL.Interfaces.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject.Factory
{
    public static class CompanyHelperFactory
    {
        public static ICompanyHelper Create()
        {
            return new CompanyHelper(DatabaseFactory.Create());
        }
    }
}
