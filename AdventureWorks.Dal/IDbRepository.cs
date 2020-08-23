using System;
using System.Linq;
using System.Linq.Expressions;

namespace AdventureWorks.Dal
{
    public interface IDbRepository<TEntity> where TEntity : class
    {
        void Create(params TEntity[] entities);
        IQueryable<TEntity> GetAll();
        IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> predicate);
        void Update(params TEntity[] entities);
        void Delete(params TEntity[] entities);
        void Delete(IQueryable<TEntity> entities);
    }
}