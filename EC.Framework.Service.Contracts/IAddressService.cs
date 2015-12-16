using System.Runtime.Remoting.Messaging;

namespace EC.Framework.Service.Contracts
{
	using EC.Framework.Service.Entities;

	public interface IAddressService
	{
		AddressItem GetAddressById(int id);
	}
}
