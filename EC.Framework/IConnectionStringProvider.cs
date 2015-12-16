namespace EC.Framework.Data.Contracts
{
    public interface IConnectionStringProvider<TConnectionStringKey>
    {
        string GetConnectionString(TConnectionStringKey connectionStringKey);
    }
}
