namespace EC.Framework.Service.Implementations
{
  using System.Collections.Generic;
  using System.Linq;

  using AutoMapper.QueryableExtensions;
  using EC.Framework.Common.Entities;
  using EC.Framework.Data.Contracts.UnitOfWorks;
  using EC.Framework.Data.Entities;
  using EC.Framework.Service.Contracts;
  using EC.Framework.Service.Entities;
  using System;
  public class EnquiryService : IEnquiryService
  {
    private readonly IDormitoryUnitOfWork unitOfWork;
    public EnquiryService(IDormitoryUnitOfWork unitOfWork)
    {
      this.unitOfWork = unitOfWork;
    }

    public IDictionary<string, Object> GetEnquiryDetails(int RoomType, DateTime FromDate, DateTime ToDate)
    {
      var roomDetails = this.unitOfWork
             .Repository<tblRoom>()
             .Query(x => x.RoomTypeId == RoomType)
             .Select(x => new RoomStatusItem
             {
               RoomID = x.RoomId,
               RoomNo = x.RoomNo,
               Capacity = x.tblRoomType.Occupancy,
               RoomStatusDetail = new List<RoomBookingDetail>() { new RoomBookingDetail { BookedDates = x.tblBookingDetails.Where(z => z.RoomId == x.RoomId).Select(a => new BookedDates() { Date = a.Date, Occupants = a.Occupants }).ToList() } },
               MaintenanceDetail = x.tblMaintenances.Where(y => y.Date >= FromDate && y.Date <= ToDate).Select(y => new RoomMaintenancegDetail
               {
                 Date = y.Date
               }).ToList()
             })
             .ToList();

      var columns = new List<string>();

      columns.Add("Room#");

      for (DateTime i = FromDate; i <= ToDate; i = i.AddDays(1))
      {
        columns.Add(i.ToString("MM/dd/yyyy"));
      }

      var rows = new Dictionary<string, Dictionary<string, object>>();

      foreach (var room in roomDetails)
      {
        var innerRow = new Dictionary<string, object>();


        for (DateTime i = FromDate; i <= ToDate; i = i.AddDays(1))
        {
          var TotalOccupants = 0;

          room.RoomStatusDetail.First().BookedDates.Where(y => y.Date == i).ToLookup(x => TotalOccupants += x.Occupants);

          if (room.MaintenanceDetail.Any(x => x.Date == i))
          {
            innerRow.Add(i.ToString("MM/dd/yyyy"), new object[] { "Not Available", room.Capacity - TotalOccupants });
          }
          else if (TotalOccupants > 0 && TotalOccupants < room.Capacity)
          {
            innerRow.Add(i.ToString("MM/dd/yyyy"), new object[] { "Partial Booked", room.Capacity - TotalOccupants });
          }
          else if (room.RoomStatusDetail.Any(x => x.BookedDates.Any(y => y.Date == i)))
          {
            innerRow.Add(i.ToString("MM/dd/yyyy"), new object[] { "Booked", room.Capacity - TotalOccupants });
          }
          else
          {
            innerRow.Add(i.ToString("MM/dd/yyyy"), new object[] { "Available", room.Capacity - TotalOccupants });
          }
        }

        rows.Add(room.RoomNo, innerRow);

      }

      var BookingDetails = new Dictionary<string, object>();
      BookingDetails.Add("columns", columns);
      BookingDetails.Add("rows", rows);

      return BookingDetails;
    }
  }
}
