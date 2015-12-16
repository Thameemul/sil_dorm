
namespace EC.Framework.Service.Contracts
{
  using System;
  using System.Collections.Generic;

  using EC.Framework.Common.Entities;
  using EC.Framework.Service.Entities;

  public interface ICartService
  {
    IEnumerable<CartItem> GetCartDetails(long CartID);
    //ICollection<CartItem> GetCartDetails(int CartID);
    Response SaveCart(long id, Int16 roomid, Dictionary<DateTime, int> dates);

    Response ConfirmCart(long id, String ContactName, String ContactEmail, String ContactNo);
    Response RemoveCartDetailByID(long CartDetailId);
  }
}
