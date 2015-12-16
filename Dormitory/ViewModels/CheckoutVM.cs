using System;

namespace Dormitory.ViewModels
{
	public class CheckOutVM
	{
		public int BookingId { get; set; }
		public short RoomId { get; set; }
		public int CustomerId { get; set; }
		public DateTime FromDate { get; set; }
		public DateTime ToDate { get; set; }
		public decimal Rent { get; set; }
		public decimal? Food { get; set; }
		public decimal? Advance { get; set; }
		public decimal Total { get; set; } 
	}
}