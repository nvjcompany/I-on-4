using DAL.Database;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DAL.Services
{
    public abstract class BaseService<T> : IMaintanable<T> where T : class, IEntityWithId
    {
        protected IDbContext db;

        private async Task<bool> SaveChanges()
        {
            try
            {
                await this.db.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
                return false;
            }
        }

        public BaseService(IDbContext db)
        {
            this.db = db;
        }

        public async Task<bool> Create(T obj)
        {
            this.db.Entry(obj).State = EntityState.Added;
            return await this.SaveChanges();
        }

        public async Task<bool> Delete(T obj)
        {
            this.db.Entry(obj).State = EntityState.Deleted;
            return await this.SaveChanges();
        }

        public async Task<T> Find(T obj)
        {
            return await this.db
                .Set<T>()
                .Where(x => x.Id == obj.Id)
                .FirstOrDefaultAsync();
        }

        public async Task<bool> Update(T obj)
        {
            this.db.Entry(obj).State = EntityState.Modified;
            return await this.SaveChanges();
        }
    }
}
