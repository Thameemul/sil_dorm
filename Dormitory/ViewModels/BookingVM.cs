
namespace Dormitory.ViewModels
{
  using System;
  using System.ComponentModel;
  using System.ComponentModel.DataAnnotations;

  using System.Collections.Generic;
  using System.Web.Mvc;
  using EC.Framework.Common.Entities;
  using EC.Framework.Service.Entities;
  public class BookingVM
  {

    [Required(ErrorMessage = "Enter From Date", AllowEmptyStrings = false)]
    public DateTime FromDate { get; set; }
    [Required(ErrorMessage = "Enter To Date", AllowEmptyStrings = false)]
    public DateTime ToDate { get; set; }
    public int RoomTypeId { get; set; }

    public List<string> Columns { get; set; }
    public Dictionary<string, Dictionary<string, object>> Rows { get; set; }
    public IEnumerable<RoomTypeItem> RoomTypes { get; set; }
    public IEnumerable<RoomItem> Rooms { get; set; }
    public long CartId { get; set; }
    public int TotalDates { get; set; }
  }
}