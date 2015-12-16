using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EC.Framework.Service.Entities
{
  public class RoomStatusItem
  {
    public RoomStatusItem()
    {
      this.RoomStatusDetail = new List<RoomBookingDetail>();
    }
    public int RoomID { get; set; }
    public string RoomNo { get; set; }
    public int Capacity { get; set; }
    public ICollection<RoomBookingDetail> RoomStatusDetail { get; set; }

    public ICollection<RoomMaintenancegDetail> MaintenanceDetail { get; set; }
  }

  public class RoomBookingDetail
  {
    public ICollection<BookedDates> BookedDates { get; set; }
  }

  public class BookedDates
  {
    public DateTime Date { get; set; }
    public int Occupants { get; set; }
  }

  public class RoomMaintenancegDetail
  {
    public DateTime Date { get; set; }
  }
}
