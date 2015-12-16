namespace EC.Framework.Test.Fakes
{
    using System.Data.Entity;

    public interface IFakeDbContext
    {
        int SaveChanges();

        DbSet<T> Set<T>() where T : class;

        void AddFakeDbSet<TEntity, TFakeDbSet>()
            where TEntity : class, new()
            where TFakeDbSet : FakeDbSet<TEntity>, IDbSet<TEntity>, new();
    }
}
