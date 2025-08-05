using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TrackWise.Database.Repository.Interface;

namespace TrackWise.Database.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly TrackWiseDbContext db;
        internal DbSet<T> dbSet;
        public Repository(TrackWiseDbContext db)
        {
            this.db = db;
            this.dbSet = db.Set<T>();
        }

        public void Add(T entity)
        {
            dbSet.Add(entity);
        }

        public void Delete(T entity)
        {
            dbSet.Remove(entity);
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            IQueryable<T> query = dbSet.Where(filter);
            return query.FirstOrDefault();

        }

        public virtual IEnumerable<T> GetAll()
        {
            IQueryable<T> query = dbSet;
            return query.ToList();
        }

        public virtual IEnumerable<T>  GetWhere(Expression<Func<T, bool>> filter)
        {
            IQueryable<T> query = dbSet.Where(filter);
            return query.ToList();
        }

        public void Save()
        {
            db.SaveChanges();
        }
        public async Task SaveAsync()
        {
           await db.SaveChangesAsync();
        }

        public void Update(T entity)
        {
            db.Update(entity);
        }
    }
}
