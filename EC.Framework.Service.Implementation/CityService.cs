

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
	public class CityService : ICityService
	{
		private readonly IDormitoryUnitOfWork unitOfWork;
		public CityService(IDormitoryUnitOfWork unitOfWork)
		{
			this.unitOfWork = unitOfWork;
		}

		public ICollection<CityItem> GetCities()
		{
			return this.unitOfWork
				.Repository<tblCity>()
				.Query()
				.Select(x=>new CityItem{CityId = x.CityId, CityName =  x.CityName,StateId = x.StateId}).ToList();
		}

		public Response SaveCity(short id, string cityName, short stateId)
		{
			var response = new Response();
			var city = unitOfWork.Repository<tblCity>().Find(id);//id

			if (city==null)
			{
				city=new tblCity();
				unitOfWork.Repository<tblCity>().Add(city);
			}

			city.CityName = cityName;
			city.StateId = stateId;

			if (!unitOfWork.SaveChanges().IsOk)
			{
				response.Error("Save Failed");
			}
			else
			{
				response.Success("Save Success");
			}

			return response;
		}
	}
}
