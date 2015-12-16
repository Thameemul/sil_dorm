﻿
namespace EC.Framework.Service.Contracts
{
	using System.Collections.Generic;
	using EC.Framework.Common.Entities;
	using EC.Framework.Service.Entities;
	public interface ICountryService
	{
		ICollection<CountryItem> GetCountries();
	}
}