using System;
using System.Data.Entity;
using System.Data.Entity.Core;
using System.Linq;
using System.Linq.Expressions;

namespace AdventureWorks.Dal
{
    public class DbRepository<TEntity> : IDbRepository<TEntity>
        where TEntity : class
    {
        protected DbContext context;

        protected DbRepository(DbContext context)
        {
            this.context = context;
        }

        public void Create(params TEntity[] entities)
        {
            try
            {
                foreach (var entity in entities)
                {
                    this.context.Entry(entity).State = EntityState.Added;
                }
                this.context.SaveChanges();
            }
            catch (EntityException e)
            {
                throw e;
            }
        }

        public IQueryable<TEntity> GetAll()
        {
            try
            {
                return this.context.Set<TEntity>().AsQueryable();
            }
            catch (EntityException e)
            {
                throw e;
            }
        }

        public IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> predicate)
        {
            try
            {
                if (predicate == null)
                {
                    throw new ArgumentNullException("predicate");
                }

                return this.context.Set<TEntity>().Where(predicate);
            }
            catch (EntityException e)
            {
                throw e;
            }
        }

        public void Update(params TEntity[] entities)
        {
            try
            {
                foreach (var entity in entities)
                {
                    this.context.Entry(entity).State = EntityState.Modified;
                }
                this.context.SaveChanges();
            }
            catch (EntityException e)
            {
                throw e;
            }
        }

        public void Delete(params TEntity[] entities)
        {
            try
            {
                foreach (var entity in entities)
                {
                    this.context.Entry(entity).State = EntityState.Deleted;
                }
                this.context.SaveChanges();
            }
            catch (EntityException e)
            {
                throw e;
            }
        }
    }
}