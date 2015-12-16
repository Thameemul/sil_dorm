using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dormitory.ViewModels;
using EC.Framework.Service.Contracts;
using EC.Framework.Service.Implementations;

namespace Dormitory.Controllers
{
  public class MasterController : Controller
  {

    private readonly IStateService stateService;
    private readonly ICommonService commonService;

    public MasterController()
    {

    }

    public MasterController(IStateService stateService, ICommonService commonService)
    {
      this.stateService = stateService;
      this.commonService = commonService;
    }

    public ActionResult MasterMenu()
    {
      return View();
    }

    public ActionResult State()
    {
      var clientQuery = this.commonService.GetCountries();
      ViewBag.Country = new SelectList(clientQuery, "CountryId", "CountryName");
      ViewBag.Codes = 1;

      //clientQuery = this.commonService.GetCountries();
      //ViewBag.State = new SelectList(clientQuery, "StateId", "State/Name");

      return View();
    }

    public ActionResult SaveState(StateVM state)
    {
      var clientQuery = this.stateService.SaveState(state.StateId, state.StateName, state.CountryId);
      JsonResult res = Json(new { success = clientQuery.IsOk, message = clientQuery.Message }, JsonRequestBehavior.AllowGet);
      return res;
    }

    public JsonResult GetCityList()
    {
      var clientQuery = this.commonService.GetCities();
      JsonResult res = Json(clientQuery, JsonRequestBehavior.AllowGet);
      return res;
    }

    public ActionResult GetStateList()
    {
      var clientQuery = this.stateService.GetStates();
      JsonResult res = Json(clientQuery, JsonRequestBehavior.AllowGet);
      return res;
    }

    public JsonResult GetCountryList()
    {
      var clientQuery = this.commonService.GetCountries();
      JsonResult res = Json(clientQuery, JsonRequestBehavior.AllowGet);
      return res;
    }
   
  }
}
