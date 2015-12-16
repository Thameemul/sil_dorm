namespace EC.Framework.Test.Fakes
{
    using System;
    using System.Collections.Generic;

    using EC.Framework.Common.Entities;
    using EC.Framework.Data.Contracts;

    public class FakeUnitOfWork : IUnitOfWork
    {
        private readonly FakeDbContext context;
        private bool disposed;        
        private Dictionary<string, object> repositories;

        public FakeUnitOfWork(FakeDbContext context)
        {
            this.context = context;
        }

        public Response SaveChanges()
        {
            return new Response();
        }

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

            var repositoryType = typeof(FakeRepository<>);

            this.repositories.Add(type, Activator.CreateInstance(repositoryType.MakeGenericType(typeof(T)), this.context));

            return (IRepository<T>)this.repositories[type];
        }

        public void BeginTransaction()
        {
        }

        public Response Commit()
        {
            return new Response();
        }

        public void Rollback()
        {
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
