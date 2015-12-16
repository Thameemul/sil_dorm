
namespace EC.Framework.Service.Contracts
{
	using System.Collections.Generic;
	using EC.Framework.Common.Entities;
	using EC.Framework.Service.Entities;
	public interface ICityService
	{
		ICollection<CityItem> GetCities();
		//CityItem GetCity(int id);
		Response SaveCity(short id, string cityName, short stateId);
	}
}
