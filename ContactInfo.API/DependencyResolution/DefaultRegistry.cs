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

namespace ContactInfo.API.DependencyResolution
{
    using ContactInfo.Data;
    using ContactInfo.Data.Common;
    using ContactInfo.Data.Implementation;
    using ContactInfo.Data.Interface;
    using ContactInfo.Service.Implementation;
    using ContactInfo.Service.Interface;
    using StructureMap.Configuration.DSL;
    using StructureMap.Graph;
    using System.Data.Entity;

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
            //For<IExample>().Use<Example>();


            #region Repository Pattern
            For<DbContext>().Use(() => new ContactInfoEntities());
            For<IUnitOfWork>().Use<UnitOfWork>();
            For<IContactInfoRepository>().Use<ContactInfoRepository>();
            For<IContactInfoService>().Use<ContactInfoService>();
            #endregion
        }

        #endregion
    }
}