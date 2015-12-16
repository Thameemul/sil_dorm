namespace EC.Framework.Test.Services
{
	using EC.Framework.Data.Entities;
	using EC.Framework.Test.Fakes;

	public class FakeDormitoryContext : FakeDbContext
	{
		public FakeDormitoryContext()
		{
			this.AddFakeDbSet<tblAddress, tblAddressDbSet>();
			this.AddFakeDbSet<tblAdvance, tblAdvanceDbSet>();
		}
	}
}
