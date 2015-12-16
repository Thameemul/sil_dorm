// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DefaultRegistry.cs" company="Web Advanced">
// Copyright 2012 Web Advanced (www.webadvanced.com)
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0

// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using EC.Framework.Data.Contracts.UnitOfWorks;
using EC.Framework.Data.Implementations.UnitOfWorks;
using EC.Framework.Service.Contracts;
using EC.Framework.Service.Implementations;

namespace Dormitory.DependencyResolution
{
  using StructureMap.Configuration.DSL;
  using StructureMap.Graph;

  public class DefaultRegistry : Registry
  {
    #region Constructors and Destructors

    public DefaultRegistry()
    {
      Scan(
        scan =>
        {
          scan.TheCallingAssembly();
          scan.WithDefaultConventions();
          scan.With(new ControllerConvention());
        });

      var connectionString = "Data Source=.;Initial Catalog=Dormitory;Persist Security Info=True;User ID=sa;Password=123456";

      For<IAddressService>().Use<AddressService>();
      For<IEnquiryService>().Use<EnquiryService>();
      For<IBookingService>().Use<BookingService>();
      For<ICartService>().Use<CartService>();
      For<IStateService>().Use<StateService>();
      For<ICommonService>().Use<CommonService>();
      For<ICityService>().Use<CityService>();
      For<IDormitoryUnitOfWork>().Use<DormitoryUnitOfWork>().Ctor<string>("connectionString").Is(connectionString);
    }

    #endregion
  }
}