namespace Dormitory.ViewModels
{
  using System;
  using System.ComponentModel;
  using System.ComponentModel.DataAnnotations;

  using System.Collections.Generic;
  using System.Web.Mvc;
  using EC.Framework.Common.Entities;
  using EC.Framework.Service.Entities;
  public class AddressVM
  {
    public string Name { get; set; }
    public int AddressId { get; set; }
    [DisplayName("Address")]
    public string Address1 { get; set; }

    public string Address2 { get; set; }

    public string Address3 { get; set; }
    [DisplayName("City")]
    public short? CityId { get; set; }
    [DisplayName("State")]
    public short? StateId { get; set; }
    [DisplayName("Country")]
    public short? CountryId { get; set; }

    public string Pincode { get; set; }

    public IEnumerable<CountryItem> Countries { get; set; }
    public IEnumerable<StateItem> States { get; set; }
    public IEnumerable<CityItem> Cities { get; set; }
  }
}