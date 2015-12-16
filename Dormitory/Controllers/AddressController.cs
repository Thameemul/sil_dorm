namespace Dormitory.Controllers
{
  using Dormitory.ViewModels;
  using EC.Framework.Service.Contracts;
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Web;
  using System.Web.Mvc;

  public class AddressController : Controller
  {
    private readonly IAddressService addressService;
    private readonly ICommonService commonService;
    public AddressController()
    {

    }

    public AddressController(IAddressService addressService, ICommonService commonService)
    {
      this.addressService = addressService;
      this.commonService = commonService;
    }

    public ActionResult Address()
    {
      AddressVM address = new AddressVM()
      {
        Countries = this.commonService.GetCountries(),
        States = this.commonService.GetStates(),
        Cities = this.commonService.GetCities()
      };

      return View(address);
    }

    public JsonResult GetStateByCountry(short countryid)
    {
      return Json(this.commonService.GetStateByCountry(countryid), JsonRequestBehavior.AllowGet);
    }

    public JsonResult GetCityByState(short stateid)
    {
      return Json(this.commonService.GetCityByState(stateid), JsonRequestBehavior.AllowGet);
    }



  }
}
