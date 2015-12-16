using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EC.Framework.Service.Entities
{
	public class AdvanceDetailsItem
	{
		public int AdvanceDetailsId { get; set; }
		public string Name { get; set; }
		public int RoomNo { get; set; }
		public DateTime BookingDate { get; set; }
		public decimal Amount { get; set; }
		
	}
}
