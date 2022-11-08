using Data;
using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Repository.Implementation
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected BigSoftContext BigSoftContext { get; set; }
        internal DbSet<T> dbSet;
        public RepositoryBase(BigSoftContext bigSoftContext)
        {
            BigSoftContext = bigSoftContext;
            this.dbSet = bigSoftContext.Set<T>();
        }

        public IQueryable<T> FindAll()
        {
            return BigSoftContext.Set<T>().AsNoTracking();
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = "")
        {
            IQueryable<T> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter).AsSplitQuery();
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty).AsSplitQuery();
            }

            if (orderBy != null)
            {
                return orderBy(query).AsSplitQuery();
            }
            else
            {
                return query.AsSplitQuery();
            }
        }


        public void Create(T entity)
        {
            BigSoftContext.Set<T>().Add(entity);
        }



        public void Update(T entity)
        {
            BigSoftContext.Set<T>().Update(entity);
            //dbSet.Attach(entity);
            //BigSoftContext.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(T entity)
        {
            BigSoftContext.Set<T>().Remove(entity);
        }

        public async Task<T> FindById(int id)
        {
            return await dbSet.FindAsync(id);
        }

        public async Task<T> FindById(string id)
        {
            return await dbSet.FindAsync(id);
        }

        public T GetById(int id)
        {
            return  dbSet.Find(id);
        }
    }
}
