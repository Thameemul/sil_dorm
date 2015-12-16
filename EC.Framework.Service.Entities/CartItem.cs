
namespace EC.Framework.Service.Entities
{
  using System;

  public class CartItem
  {
    public long CartDetailID { get; set; }
    public String RoomNo { get; set; }
    public DateTime Date { get; set; }
    public string RoomType { get; set; }
    public Decimal Food { get; set; }
    public int Occupancy { get; set; }
    public Decimal RoomRent { get; set; }
    public Decimal Total { get; set; }
    public int RemainingCapacity { get; set; }
  }
}
