namespace Dormitory.Controllers
{
  using Dormitory.ViewModels;
  using EC.Framework.Service.Contracts;
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Web;
  using System.Web.Mvc;
  using System.Web.Script.Serialization;
  public class CartController : Controller
  {
    private readonly ICartService cartservice;
    private readonly IBookingService bookingservice;

    public CartController()
    {

    }
    public CartController(ICartService cartservice, IBookingService bookingservice)
    {
      this.cartservice = cartservice;
      this.bookingservice = bookingservice;
    }

    [HttpPost]
    public JsonResult AddItems(long CartId, Int16 RoomId, String[] Dates)
    {

      Dictionary<String, String> lst = (new JavaScriptSerializer()).Deserialize<Dictionary<String, String>>(Dates[0]);


      Dictionary<DateTime, int> lstDates = new Dictionary<DateTime, int>();// (new JavaScriptSerializer()).Deserialize<Dictionary<DateTime, int>>(Dates[0]);

      lst.AsEnumerable().ToLookup(x => { lstDates.Add(Convert.ToDateTime(x.Key), Convert.ToInt32(x.Value)); return x; });
      var cartdet = cartservice.SaveCart(CartId, RoomId, lstDates);

      Session["CartId"] = cartdet.IsOk ? cartdet.Message : "0";

      JsonResult res = Json(new { Success = cartdet.IsOk, ReturnValue = cartdet.ReturnValue }, JsonRequestBehavior.AllowGet);
      return res;
    }

    [HttpGet]
    public ActionResult ViewCart()
    {
      if (Session["CartId"] == null || Convert.ToInt64(Session["CartId"]) == 0)
      {
        return RedirectToAction("Enquiry", "Enquiry");
      }

      var Query = this.cartservice.GetCartDetails(Session["CartId"] == null ? 0 : Convert.ToInt64(Session["CartId"]));

      CartVM cm = new CartVM()
      {
        CartDetails = Query
      };
      return View(cm);
    }

    public JsonResult ConfirmCart(String ContactName, String ContactEmail, String ContactNo)
    {
      var CartId = Session["CartId"] == null ? 0 : Convert.ToInt64(Session["CartId"]);
      var res = this.cartservice.ConfirmCart(CartId, ContactName, ContactEmail, ContactNo);

      if (res.IsOk)
      {
        Session["CartId"] = null;
      }

      return Json(new { Success = res.IsOk, BookingId = res.IsOk ? res.ReturnValue : "0" }, JsonRequestBehavior.AllowGet);
    }

    public JsonResult RemoveCartDetail(long CartDetailId)
    {
      var res = this.cartservice.RemoveCartDetailByID(CartDetailId);
      return Json(new { Success = res.IsOk }, JsonRequestBehavior.AllowGet);
    }

    public ActionResult BookingConfirmation(int BookingId)
    {
      var Query = this.bookingservice.GetBookingDetails(BookingId);

      BookingConfirmationVM bm = new BookingConfirmationVM()
      {
        Booking = Query
      };

      return View(bm);
    }

  }
}
