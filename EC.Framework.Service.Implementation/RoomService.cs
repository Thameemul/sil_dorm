
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
	public class RoomService : IRoomService
	{

		private readonly IDormitoryUnitOfWork unitOfWork;
    public RoomService(IDormitoryUnitOfWork unitOfWork)
		{
			this.unitOfWork = unitOfWork;
		}


    ICollection<RoomItem> IRoomService.GetRooms()
    {
			return this.unitOfWork
        .Repository<tblRoom>()
				.Query()
				.Select()
        .ProjectTo<RoomItem>()
				.ToList();
    }
  }
}
