

namespace EC.Framework.Service.Entities
{
	public class AddressItem
	{
		public int AddressId { get; set; }
		public string Address1 { get; set; }
		
		public string Address2 { get; set; }
	
		public string Address3 { get; set; }
		public short? CityId { get; set; }
		public short? StateId { get; set; }
		public short? CountryId { get; set; }
		public string Pincode { get; set; }
	}
}
