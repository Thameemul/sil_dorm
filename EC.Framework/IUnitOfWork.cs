namespace EC.Framework.Data.Contracts
{
    using EC.Framework.Common.Entities;

    public interface IUnitOfWork
    {
        Response SaveChanges();

        void Dispose(bool disposing);

        IRepository<T> Repository<T>() where T : class;

        void BeginTransaction();

        Response Commit();

        void Rollback();
    }
}
