using DAL.Helpers;
using DAL.Interfaces.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject.Factory
{
    static class IdentityHelperFactory
    {
        public static IIdentityHelper Create()
        {
            return new IdentityHelper(DatabaseFactory.Create());
        }
    }
}
