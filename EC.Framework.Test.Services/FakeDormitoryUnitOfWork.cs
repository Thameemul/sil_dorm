using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EC.Framework.Data.Contracts.UnitOfWorks;
using EC.Framework.Test.Fakes;

namespace EC.Framework.Test.Services
{
	public class FakeDormitoryUnitOfWork : FakeUnitOfWork, IDormitoryUnitOfWork
	{
		public FakeDormitoryUnitOfWork(FakeDbContext context)
			: base(context)
		{

		}
	}
}
