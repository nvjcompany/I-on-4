using DAL.Database;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using DAL.Interfaces.Services;

namespace DAL.Services
{
    public abstract class BaseService<T> : IMaintanable<T> where T : class, IEntityWithId
    {
        protected IDbContext db;

        private async Task<bool> SaveChanges()
        {
            await this.db.SaveChangesAsync();

            return true;
            /*try
            {
                await this.db.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
#pragma warning disable CS0162 // Unreachable code detected
                return false;
#pragma warning restore CS0162 // Unreachable code detected
            }*/
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
            T existing = this.db.Set<T>().Find(obj.Id);
            this.db.Entry(existing).State = EntityState.Deleted;
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
            T existing = this.db.Set<T>().Find(obj.Id);
            if (existing != null)
            {
                this.db.Entry(existing).CurrentValues.SetValues(obj);
                //context.SaveChanges();
            }

            // this.db.Entry(obj).State = EntityState.Modified;
            //this.db.Set<T>().Add(obj);
            return await this.SaveChanges();
        }
    }
}
