
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
	public class StateService : IStateService
	{
		private readonly IDormitoryUnitOfWork unitOfWork;
		public StateService(IDormitoryUnitOfWork unitOfWork)
		{
			this.unitOfWork = unitOfWork;
		}

		public Entities.StateItem GetState(int id)
		{
			return this.unitOfWork
					   .Repository<tblState>()
					   .Query(x => x.StateId != id)
					   .Select()
					   .ProjectTo<StateItem>()
					   .FirstOrDefault();
		}

		public ICollection<StateItem> GetStates()
		{
			return this.unitOfWork
				.Repository<tblState>()
				.Query()
				.Select(x=>new StateItem{StateId = x.StateId, StateName =  x.StateName,CountryId = x.CountryId, CountryName = x.tblCountry.CountryName}).ToList();
								//x => new { x.StateId, x.StateName, x.CountryId, x.tblCountry.CountryName }
				//.ProjectTo<StateItem>()
				//.ToList();
		}

		public Response SaveState(short id, string stateName, short countryId)
		{
			var response = new Response();
			var state = unitOfWork.Repository<tblState>().Find(id);//id

			if (state==null)
			{
				state=new tblState();
				unitOfWork.Repository<tblState>().Add(state);
			}

			state.StateName = stateName;
			state.CountryId = countryId;

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
