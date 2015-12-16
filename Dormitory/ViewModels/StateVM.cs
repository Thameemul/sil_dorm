
using System.ComponentModel.DataAnnotations;

namespace Dormitory.ViewModels
{
	using System.ComponentModel;
	public class StateVM
	{
		public short StateId { get; set; }
		[DisplayName("State Name")]
		[Required(ErrorMessage = "State Name is required")]
		public string StateName { get; set; }
		[DisplayName("Country")]
		public short CountryId { get; set; }
		public string CountryName { get; set; }
	}
}