
namespace Dormitory.ViewModels
{
  using System;
  using System.ComponentModel;
  using System.ComponentModel.DataAnnotations;

  using System.Collections.Generic;
  using System.Web.Mvc;
  using EC.Framework.Common.Entities;
  using EC.Framework.Service.Entities;
  public class CartVM
  {
     public IEnumerable<CartItem> CartDetails { get; set; }

     [Required(ErrorMessage = "Enter Name", AllowEmptyStrings = false)]
     public String Name { get; set; }
     [Required(ErrorMessage = "Enter Email", AllowEmptyStrings = false)]
     public String Email { get; set; }
     [Required(ErrorMessage = "Enter Contact Number", AllowEmptyStrings = false)]
     public String ContactNo { get; set; }
  }
}