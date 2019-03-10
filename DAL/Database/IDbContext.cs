﻿using DAL.Entities;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DAL.Database
{
    public interface IDbContext
    {
        int SaveChanges();
        Task<int> SaveChangesAsync();
        IDbSet<User> Users { get; set; }
        IDbSet<IdentityRole> Roles { get; set; }
        IDbSet<City> Cities { get; set; }
        IDbSet<Campaign> Campaigns { get; set; }
        IDbSet<Listing> Listings { get; set; }
        IDbSet<Company> Companies { get; set; }
    }
}
