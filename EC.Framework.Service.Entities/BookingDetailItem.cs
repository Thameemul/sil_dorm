using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EC.Framework.Service.Entities
{
  public class BookingDetailItem
  {
    public long BookingId { get; set; }
    public String RoomNo { get; set; }
    public DateTime Date { get; set; }
    public string RoomType { get; set; }
    public Decimal Food { get; set; }
    public int Occupancy { get; set; }
    public Decimal RoomRent { get; set; }
  }
}
