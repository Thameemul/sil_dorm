
namespace Dormitory.Controllers
{
  using Dormitory.ViewModels;
  using EC.Framework.Service.Contracts;
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Web;
  using System.Web.Mvc;

  public class EnquiryController : Controller
  {
    //
    // GET: /Enquiry/
    private readonly IEnquiryService enquiryservice;
    private readonly ICommonService commonService;
    public EnquiryController()
    {

    }

    public EnquiryController(IEnquiryService enquiryservice, ICommonService commonService)
    {
      this.enquiryservice = enquiryservice;
      this.commonService = commonService;
    }

    public ActionResult Enquiry()
    {
        var roomTypes = this.commonService.GetRoomTypes();
      var query = this.enquiryservice.GetEnquiryDetails(roomTypes.First().RoomTypeId, DateTime.Now.Date, DateTime.Now.AddDays(7).Date);
      EnquiryVM em = new EnquiryVM()
      {
        Columns = query["columns"] as List<string>,
        Rows = query["rows"] as Dictionary<string, Dictionary<string, object>>,
        RoomTypes = roomTypes,
        Rooms = this.commonService.GetRooms(),
        FromDate = DateTime.Now.Date,
        ToDate = DateTime.Now.AddDays(7).Date
      };


      return View(em);
    }

    [HttpPost]
    public ActionResult Enquiry(EnquiryVM viewModel)
    {
      if (!ModelState.IsValid)
      {
        var roomTypes = this.commonService.GetRoomTypes();
        var query = this.enquiryservice.GetEnquiryDetails(roomTypes.First().RoomTypeId, DateTime.Now.Date, DateTime.Now.AddDays(7).Date);

        viewModel.Columns = query["columns"] as List<string>;
        viewModel.Rows = query["rows"] as Dictionary<string, Dictionary<string, object>>;
        viewModel.RoomTypes = roomTypes;
        viewModel.Rooms = this.commonService.GetRooms();

        return View(viewModel);
      }

      TempData["EnquiryVM"] = viewModel;

      return this.RedirectToAction("Booking", "Booking", viewModel);
    }

    public ActionResult GetEnquiry(int RoomTypeId, DateTime FromDate, DateTime ToDate)
    {
      var query = this.enquiryservice.GetEnquiryDetails(RoomTypeId, FromDate, ToDate);
      EnquiryVM em = new EnquiryVM()
      {
        Columns = query["columns"] as List<string>,
        Rows = query["rows"] as Dictionary<string, Dictionary<string, object>>,
        RoomTypes = this.commonService.GetRoomTypes(),
        Rooms = this.commonService.GetRooms(),
        FromDate = FromDate,
        ToDate = ToDate
      };


      return View("Enquiry", em);
    }

  }
}
