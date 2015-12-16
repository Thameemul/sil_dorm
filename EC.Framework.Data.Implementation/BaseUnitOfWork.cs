namespace EC.Framework.Data.Implementations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;

    using EC.Framework.Common.Entities;
    using EC.Framework.Data.Contracts;

    public abstract class BaseUnitOfWork<TContext> : IUnitOfWork where TContext : BaseContext<TContext>
    {
        private readonly DbContext context;
        private bool disposed;
        private Dictionary<string, object> repositories;
        private DbContextTransaction transaction;

        protected BaseUnitOfWork(string connectionString)
        {
            this.context = (BaseContext<TContext>)Activator.CreateInstance(typeof(TContext), connectionString);
        }

        public Response SaveChanges()
        {
            var response = new Response();
            try
            {
                this.context.SaveChanges();
            }
            catch (Exception ex)
            {
                response.Error("SaveChanges", ex.Message);
            }

            return response;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.ReadabilityRules", "SA1101:PrefixLocalCallsWithThis", Justification = "Reviewed.")]
        public IRepository<T> Repository<T>() where T : class
        {
            if (this.repositories == null)
            {
                this.repositories = new Dictionary<string, object>();
            }

            var type = typeof(T).Name;

            if (this.repositories.ContainsKey(type))
            {
                return (IRepository<T>)this.repositories[type];
            }

            var repositoryType = typeof(Repository<>);

            this.repositories.Add(type, Activator.CreateInstance(repositoryType.MakeGenericType(typeof(T)), this.context));

            return (IRepository<T>)this.repositories[type];
        }

        public void BeginTransaction()
        {
            this.transaction = this.context.Database.BeginTransaction();
        }

        public Response Commit()
        {
            var response = new Response();
            try
            {
                this.transaction.Commit();
            }
            catch (Exception ex)
            {
                response.Error("SaveChanges", ex.Message);
            }

            return response;
        }

        public void Rollback()
        {
            this.transaction.Rollback();
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    this.context.Dispose();
                }
            }

            this.disposed = true;
        }
    }
}
