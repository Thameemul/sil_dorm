
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
	public class RoomTypeService : IRoomTypeService
	{

		private readonly IDormitoryUnitOfWork unitOfWork;
    public RoomTypeService(IDormitoryUnitOfWork unitOfWork)
		{
			this.unitOfWork = unitOfWork;
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
