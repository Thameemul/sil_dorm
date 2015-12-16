using EC.Framework.Service.Contracts;
using System.Web.Mvc;

namespace Dormitory.Controllers
{

  public class CheckInController : Controller
  {
    //private readonly ICheckInService checkInService;

    //public CheckInController(ICheckInService checkInService)
    //{
    //	this.checkInService = checkInService;
    //}

    public ActionResult CheckIn()
    {
      return View();
    }

  }
}
