using System;
using VPNHelperCommon.Clients;
using VPNHelperCommon.Clients.Configuration;
using VPNHelperCommon.Models;

namespace VPNHelperCommon
{
    public class DIModule : Ninject.Modules.NinjectModule
    {
        #region Methods

        public override void Load()
        {
            Kernel.Bind<IJsonApiClient>().To<JsonApiClient>();
            Kernel.Bind<INordVPNApiClient>().To<NordVPNApiClient>();
            Kernel.Bind<IApiClientConfiguration>().To<ApiClientConfiguration>();
            Kernel.Bind<INordVPNApiClientConfiguration>().To<NordVPNApiClientConfiguration>().InSingletonScope();

            Kernel.Bind<IResult>().To<Result>();
        }

        #endregion Methods
    }
}