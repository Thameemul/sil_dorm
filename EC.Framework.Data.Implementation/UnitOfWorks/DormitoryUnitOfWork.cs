namespace EC.Framework.Data.Implementations.UnitOfWorks
{
	using EC.Framework.Data.Contracts.UnitOfWorks;

	public class DormitoryUnitOfWork : BaseUnitOfWork<DormitoryContext>, IDormitoryUnitOfWork
	{
		public DormitoryUnitOfWork(string connectionString)
			: base(connectionString)
		{
			 
		}
	}
}
