using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IRepositoryBase<T>
    {
        IQueryable<T> FindAll();
        IQueryable<T> FindByCondition(
           Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = "");
        void Create(T entity);
        Task<T> FindById(int id);
        T GetById(int id);
        Task<T> FindById(string id);
        void Update(T entity);
        void Delete(T entity);

    }
}
