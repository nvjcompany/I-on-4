using DAL.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Database
{
    public class IesDbContext : IdentityDbContext<User>, IDbContext
    {
        public IesDbContext() : base("IES")
        {
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
        }

        public override IDbSet<User> Users { get; set; }
        public IDbSet<City> Cities { get; set; }
        public IDbSet<Campaign> Campaigns { get; set; }
        public IDbSet<Listing> Listings { get; set; }
        public IDbSet<Company> Companies { get; set; }
        public IDbSet<Application> Applications { get; set; }
    }
}
