using System;
using EC.Framework.Service.Entities;

namespace EC.Framework.Service.Contracts
{
	public interface IAdvanceDetailsService
	{
		AdvanceDetailsItem GetAdvanceDetailsDetails(DateTime checkInDate);
	}
}
