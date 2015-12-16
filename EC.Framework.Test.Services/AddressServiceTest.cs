using System.Runtime.InteropServices;
using EC.Framework.Data.Contracts;
using EC.Framework.Data.Contracts.UnitOfWorks;
using EC.Framework.Data.Entities;
using EC.Framework.Service.Implementations;
using EC.Framework.Test.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EC.Framework.Test.Services
{
	[TestClass]
	public class AddressServiceTest
	{
		[TestInitialize]
		public void AddressServiceTestInitialization()
		{
			EC.Framework.Service.Implementations.AutomapperConfig.Initialize();
		}

		[TestMethod]
		public void GetAddressById_Can_Return_A_Item()
		{
			// Assign
			var address = new tblAddress
			{
				AddressId = 1,
				Address1 = "Test"
			};

			var context = new FakeDormitoryContext();

			context.Seed(address);

			var unitOfWork = new FakeDormitoryUnitOfWork(context);

			var service = new AddressService(unitOfWork);

			// Act

			var item = service.GetAddressById(1);

			// Assert

			Assert.IsNotNull(item);
			Assert.IsTrue(item.Address1==address.Address1);
		}
	}
}
