using System;
using VPNHelperService.Services;

namespace VPNHelperService
{
    public class DIModule : Ninject.Modules.NinjectModule
    {
        #region Methods

        public override void Load()
        {
            Kernel.Bind<INordVPNService>().To<NordVPNService>();
        }

        #endregion Methods
    }
}