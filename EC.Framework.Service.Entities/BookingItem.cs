using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EC.Framework.Service.Entities
{
  public class BookingItem
  {
    public long BookingId { get; set; }
    public DateTime BookedOn { get; set; }
    public String ContactName { get; set; }
    public String ContactEmail { get; set; }
    public String ContactNo { get; set; }
    public List<BookingDetailItem> RoomBookingDetails { get; set; }

  }
}
