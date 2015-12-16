
namespace EC.Framework.Service.Contracts
{
  using System.Collections.Generic;
  using EC.Framework.Service.Entities;
  public interface ICommonService
  {
    ICollection<StateItem> GetStates();
    ICollection<CityItem> GetCities();
    ICollection<CountryItem> GetCountries();
    ICollection<RoomItem> GetRooms();
    ICollection<RoomItem> GetRoomsByRoomType(byte RoomTypeId);
    ICollection<RoomTypeItem> GetRoomTypes();
    ICollection<StateItem> GetStateByCountry(short CountryId);
    ICollection<CityItem> GetCityByState(short StateId);
  }
}
