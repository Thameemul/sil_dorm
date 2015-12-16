
namespace EC.Framework.Service.Implementations
{
	using System.Collections.Generic;
	using System.Linq;

	using AutoMapper.QueryableExtensions;
	using EC.Framework.Common.Entities;
	using EC.Framework.Data.Contracts.UnitOfWorks;
	using EC.Framework.Data.Entities;
	using EC.Framework.Service.Contracts;
	using EC.Framework.Service.Entities;
	public class CountryService : ICountryService
	{

		private readonly IDormitoryUnitOfWork unitOfWork;
		public CountryService(IDormitoryUnitOfWork unitOfWork)
		{
			this.unitOfWork = unitOfWork;
		}

		public ICollection<CountryItem> GetCountries()
		{
			return this.unitOfWork
				.Repository<tblCountry>()
				.Query()
				.Select()
				.ProjectTo<CountryItem>()
				.ToList();
			//				.Select(x => new CountryItem { CountryId = x.CountryId, CountryName = x.CountryName}).ToList();
		}

	}
}
