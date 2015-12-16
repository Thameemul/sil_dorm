using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dormitory.ViewModels;
using EC.Framework.Service.Entities;

namespace Dormitory.App_Start
{
	public static class AutoMapperConfig
	{
		public static void Initialize()
		{
			Mapper.CreateMap<AddressVM, AddressItem>();
			Mapper.CreateMap<AddressItem, AddressVM>();

			Mapper.CreateMap<StateVM, StateItem>();
			Mapper.CreateMap<StateItem, StateVM>();
		}
	}
}