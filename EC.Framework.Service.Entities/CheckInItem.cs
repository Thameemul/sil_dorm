using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EC.Framework.Service.Entities
{
	public class CheckInItem
	{
		public int CheckInId { get; set; }
		public string PersonName { get; set; }
		public int RoomNo { get; set; }
		public bool CheckIn { get; set; }
		public bool Cancel { get; set; }
		public bool Change { get; set; }
	}
}
