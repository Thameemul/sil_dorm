namespace EC.Framework.Test.Services
{
	using System.Linq;

	using EC.Framework.Data.Entities;
	using EC.Framework.Test.Fakes;

	public class tblAddressDbSet : FakeDbSet<tblAddress>
	{
		public override tblAddress Find(params object[] keyValues)
		{
			return this.SingleOrDefault(x => x.AddressId == (int)keyValues.First());
		}
	}

	public class tblAdvanceDbSet : FakeDbSet<tblAdvance>
	{
		public override tblAdvance Find(params object[] keyValues)
		{
			return this.SingleOrDefault(x => x.BookingId == (int)keyValues.First() && x.RoomId == (int)keyValues[1]);
		}
	}
}
