
namespace EC.Framework.Service.Contracts
{
	using System.Collections.Generic;
	using EC.Framework.Common.Entities;
	using EC.Framework.Service.Entities;

	public interface IStateService
	{
		ICollection<StateItem> GetStates();
		//StateItem GetState(int id);
		Response SaveState(short id, string stateName, short countryId);
	}
}
