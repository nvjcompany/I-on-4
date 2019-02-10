using DAL.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject
{
    public static class DatabaseFactory
    {
        public static IDbContext Create()
        {
            return new IesDbContext();
        }
    }
}
