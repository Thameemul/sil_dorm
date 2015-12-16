
namespace Dormitory.Controllers
{
  using Dormitory.ViewModels;
  using EC.Framework.Service.Contracts;
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Web;
  using System.Web.Mvc;

  public class BookingController : Controller
  {
    //
    // GET: /Enquiry/
    private readonly IBookingService bookingservice;
    private readonly ICommonService commonService;
    public BookingController()
    {

    }

    public BookingController(IBookingService bookingservice, ICommonService commonService)
    {
      this.bookingservice = bookingservice;
      this.commonService = commonService;
    }

    public ActionResult Booking(EnquiryVM enquiryVM = null)
    {
      //var enquiryVM = TempData["EnquiryVM"] as EnquiryVM;

      var roomTypes = this.commonService.GetRoomTypes();
      if (enquiryVM.RoomTypeId == 0)
      {
        enquiryVM = new EnquiryVM()
        {
          FromDate = DateTime.Now.Date,
          ToDate = DateTime.Now.AddDays(7).Date,
          RoomTypeId = roomTypes.First().RoomTypeId
        };
        //return this.RedirectToAction("Enquiry");
      }

      var rooms = this.commonService.GetRoomsByRoomType(enquiryVM.RoomTypeId);
      var query = this.bookingservice.GetBookingDetails(enquiryVM.RoomTypeId, enquiryVM.FromDate, enquiryVM.ToDate, rooms.First().RoomId);

      BookingVM bm = new BookingVM()
      {
        Columns = query["columns"] as List<string>,
        Rows = query["rows"] as Dictionary<string, Dictionary<string, object>>,
        RoomTypes = roomTypes,
        Rooms = rooms,
        FromDate = enquiryVM.FromDate,
        ToDate = enquiryVM.ToDate,
        CartId = Session["CartId"] == null ? 0 : Convert.ToInt64(Session["CartId"]),
        RoomTypeId = enquiryVM.RoomTypeId,
        TotalDates = Session["CartId"] == null ? 0 : this.bookingservice.GetBookingDatesCount(Convert.ToInt64(Session["CartId"]))
      };

      return View(bm);
    }

    public ActionResult GetBooking(byte RoomTypeId, DateTime FromDate, DateTime ToDate, int RoomId)
    {
      var Query = this.bookingservice.GetBookingDetails(RoomTypeId, FromDate, ToDate, RoomId);

      BookingVM bm = new BookingVM()
      {
        Columns = Query["columns"] as List<string>,
        Rows = Query["rows"] as Dictionary<string, Dictionary<string, object>>,
        RoomTypes = this.commonService.GetRoomTypes(),
        Rooms = this.commonService.GetRoomsByRoomType(RoomTypeId),
        FromDate = FromDate,
        ToDate = ToDate,
        RoomTypeId = RoomTypeId,
        CartId = Session["CartId"] == null ? 0 : Convert.ToInt64(Session["CartId"]),
        TotalDates = Session["CartId"] == null ? 0 : this.bookingservice.GetBookingDatesCount(Convert.ToInt64(Session["CartId"]))
      };

      return View("Booking", bm);
    }

    public JsonResult GetRoomsByType(byte RoomType)
    {
      return Json(this.commonService.GetRoomsByRoomType(RoomType), JsonRequestBehavior.AllowGet);
    }

  }
}
