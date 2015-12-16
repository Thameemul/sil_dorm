using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Dormitory.ViewModels
{
	public class AdvanceDetailsVM
	{
		public int AdvanceDetailsId { get; set; }
		public string Name { get; set; }
		public int RoomNo { get; set; }
		[DisplayName("Booking Date")]
		[DataType(DataType.Date)]
		public DateTime BookingDate { get; set; }
		public decimal Amount { get; set; }
	}
}