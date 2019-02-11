using DAL.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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

        public IesDbContext(string con) : base(con)
        {
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
        }

        public override IDbSet<User> Users { get; set; }
        //DbSet<User> IDbContext.Users { get => throw new NotImplementedException();}
        //DbSet<IdentityRole> IDbContext.Roles { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
