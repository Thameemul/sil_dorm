namespace EC.Framework.Test.Fakes
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Linq.Expressions;

    using EC.Framework.Data.Contracts;
    using LinqKit;

    public class FakeRepository<T> : IRepository<T> where T : class
    {
        private readonly FakeDbContext context;
        private readonly DbSet<T> dbset;

        public FakeRepository(FakeDbContext context)
        {
            this.context = context;
            this.dbset = this.context.Set<T>();
        }

        public void Add(T item)
        {
            this.dbset.Add(item);
        }

        public void AddItems(IEnumerable<T> items)
        {
            this.dbset.AddRange(items);
        }

        public void DeleteItems(IEnumerable<T> items)
        {
            this.dbset.RemoveRange(items);
        }

        public void Remove(T item)
        {
            this.dbset.Remove(item);
        }

        public T Find(params object[] keyValues)
        {
            return this.dbset.Find(keyValues);
        }

        public IQueryable<T> SelectQuery(string query, params object[] parameters)
        {
            return this.dbset.SqlQuery(query, parameters).AsQueryable();
        }

        public void Insert(T entity)
        {
            this.dbset.Attach(entity);
        }

        public void Delete(object id)
        {
            var entity = this.Find(id);
            this.Delete(entity);
        }

        public void Delete(T entity)
        {
            this.dbset.Attach(entity);
            this.dbset.Remove(entity);
        }

        public void Update(T entity)
        {
            this.dbset.Attach(entity);
        }

        public IQueryFluent<T> Query(Expression<Func<T, bool>> query)
        {
            return new FakeQueryFluent<T>(this, query);
        }

        public IQueryFluent<T> Query()
        {
            return new FakeQueryFluent<T>(this);
        }

        internal IQueryable<T> Select(
                                      Expression<Func<T, bool>> filter = null,
                                      Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                                      List<Expression<Func<T, object>>> includes = null,
                                      int? page = null,
                                      int? pageSize = null)
        {
            IQueryable<T> query = this.dbset;

            if (includes != null)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }

            if (orderBy != null)
            {
                query = orderBy(query);
            }

            if (filter != null)
            {
                query = query.AsExpandable().Where(filter);
            }

            if (page != null && pageSize != null)
            {
                query = query.Skip((page.Value - 1) * pageSize.Value).Take(pageSize.Value);
            }

            return query;
        }
    }
}
