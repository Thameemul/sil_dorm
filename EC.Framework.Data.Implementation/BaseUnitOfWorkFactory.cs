namespace EC.Framework.Data.Implementations
{
    using System;
    using EC.Framework.Data.Contracts;

    public abstract class BaseUnitOfWorkFactory<T, TConnectionStringKey> : IUnitOfWorkFactory<TConnectionStringKey> where T : IUnitOfWork
    {
        private readonly IConnectionStringProvider<TConnectionStringKey> connectionStringProvider;

        protected BaseUnitOfWorkFactory(IConnectionStringProvider<TConnectionStringKey> connectionStringProvider)
        {
            this.connectionStringProvider = connectionStringProvider;
        }

        public IUnitOfWork GetUnitOfWork(TConnectionStringKey connectionStringKey)
        {
            return (IUnitOfWork)Activator.CreateInstance(typeof(T), this.connectionStringProvider.GetConnectionString(connectionStringKey));
        }
    }
}
