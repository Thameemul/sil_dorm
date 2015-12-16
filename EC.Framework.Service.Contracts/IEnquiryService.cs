
namespace EC.Framework.Service.Contracts
{
  using System;
  using System.Collections.Generic;

  using EC.Framework.Common.Entities;
  using EC.Framework.Service.Entities;

  public interface IEnquiryService
  {
    IDictionary<string, Object> GetEnquiryDetails(int RoomType, DateTime FromDate, DateTime ToDate);   
  }
}
