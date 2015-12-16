namespace EC.Framework.Service.Implementations
{
	using System;
	using System.Linq;

	using AutoMapper.QueryableExtensions;
	using EC.Framework.Data.Contracts.UnitOfWorks;
	using EC.Framework.Data.Entities;
	using EC.Framework.Service.Contracts;
	using EC.Framework.Service.Entities;

	public class AddressService : IAddressService
	{
		private readonly IDormitoryUnitOfWork unitOfWork;
		public AddressService(IDormitoryUnitOfWork unitOfWork)
		{
			this.unitOfWork = unitOfWork;
		}

		public Entities.AddressItem GetAddressById(int id)
		{
			return this.unitOfWork
					   .Repository<tblAddress>()
					   .Query(x => x.AddressId == id)
					   .Select()
					   .ProjectTo<AddressItem>()
					   .FirstOrDefault();
		}
	}
}
