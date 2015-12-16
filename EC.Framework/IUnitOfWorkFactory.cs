namespace EC.Framework.Data.Contracts
{
    public interface IUnitOfWorkFactory<TConnectionStringKey>
    {
        IUnitOfWork GetUnitOfWork(TConnectionStringKey connectionStringKey);
    }
}
