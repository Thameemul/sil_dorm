
namespace EC.Framework.Service.Contracts
{
  using System;
  using System.Collections.Generic;

  using EC.Framework.Common.Entities;
  using EC.Framework.Service.Entities;

  public interface IBookingService
  {
    IDictionary<string, Object> GetBookingDetails(int RoomType, DateTime FromDate, DateTime ToDate, int RoomId);
    BookingItem GetBookingDetails(int BookingId);
    int GetBookingDatesCount(long CartId);
  }
}
