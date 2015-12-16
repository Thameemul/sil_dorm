using System.ComponentModel;

namespace Dormitory.ViewModels
{
	public class CheckInVM
	{

			public int CheckInId { get; set; }

			[DisplayName("Name")]
			public string PersonName { get; set; }

			public int RoomNo { get; set; }

			public bool CheckIn { get; set; }

			public bool Cancel { get; set; }

			public bool Change { get; set; }

	}
}