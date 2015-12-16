
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
	public class CommonService : ICommonService
	{



		private readonly IDormitoryUnitOfWork unitOfWork;

    public ICollection<StateItem> GetStateByCountry(short CountryId)
    {
      return this.unitOfWork
        .Repository<tblState>()
        .Query(m => m.CountryId == CountryId)
        .Select()
        .ProjectTo<StateItem>()
        .ToList();
    }

    public ICollection<CityItem> GetCityByState(short StateId)
    {
      return this.unitOfWork
        .Repository<tblCity>()
        .Query(m => m.StateId == StateId)
        .Select()
        .ProjectTo<CityItem>()
        .ToList();
    }

		public CommonService(IDormitoryUnitOfWork unitOfWork)
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
		}

		public ICollection<StateItem> GetStates()
		{
			return this.unitOfWork
				.Repository<tblState>()
				.Query()
				.Select()
				.ProjectTo<StateItem>()
				.ToList();
		}

		public ICollection<CityItem> GetCities()
		{
			return this.unitOfWork
				.Repository<tblCity>()
				.Query()
				.Select()
				.ProjectTo<CityItem>()
				.ToList();
		}
		public ICollection<RoomItem> GetRooms()
		{
			return this.unitOfWork
				.Repository<tblRoom>()
				.Query()
				.Select()
				.ProjectTo<RoomItem>()
				.ToList();
		}

		public ICollection<RoomItem> GetRoomsByRoomType(byte RoomTypeId)
		{
			return this.unitOfWork
				.Repository<tblRoom>()
				.Query( m => m.RoomTypeId == RoomTypeId)
				.Select()
				.ProjectTo<RoomItem>()
				.ToList();
		}

		public ICollection<RoomTypeItem> GetRoomTypes()
		{
			return this.unitOfWork
				.Repository<tblRoomType>()
				.Query()
				.Select()
				.ProjectTo<RoomTypeItem>()
				.ToList();
		}
	}
}
