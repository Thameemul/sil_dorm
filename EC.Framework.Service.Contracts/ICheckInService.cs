using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EC.Framework.Service.Entities;

namespace EC.Framework.Service.Contracts
{
	public interface ICheckInService
	{
		CheckInItem GetCheckInDetails(DateTime checkInDate);
	}
}
