namespace EC.Framework.Service.Implementations
{
  using AutoMapper;
  using EC.Framework.Data.Entities;
  using EC.Framework.Service.Entities;

  public static class AutomapperConfig
  {
    public static void Initialize()
    {
      Mapper.CreateMap<tblAddress, AddressItem>();
      Mapper.CreateMap<AddressItem, tblAddress>();

      Mapper.CreateMap<tblState, StateItem>()
        .ForMember(x => x.CountryName, y => y.Ignore());
      Mapper.CreateMap<StateItem, tblState>();

      Mapper.CreateMap<tblCountry, CountryItem>();
      Mapper.CreateMap<CountryItem, tblCountry>();

      Mapper.CreateMap<tblCity, CityItem>()
        .ForMember(x => x.StateName, y => y.MapFrom(z => z.tblState.StateName));
      Mapper.CreateMap<CityItem, tblCity>();

      Mapper.CreateMap<tblRoomType, RoomTypeItem>();
      Mapper.CreateMap<RoomTypeItem, tblRoomType>();

      Mapper.CreateMap<tblRoom, RoomItem>();
      Mapper.CreateMap<RoomItem, tblRoom>();

      Mapper.CreateMap<tblCartDetail, CartItem>();
      Mapper.CreateMap<CartItem, tblCartDetail>();


    }
  }
}
