using Caliburn.Micro;
using System;
using VPNHelperService.Services;
using VPNHelperUI.ViewModels;

namespace VPNHelperUI
{
    public class DIModule : Ninject.Modules.NinjectModule
    {
        #region Methods

        public override void Load()
        {
            Kernel.Bind<IWindowManager>().To<WindowManager>().InSingletonScope();
            Kernel.Bind<IEventAggregator>().To<EventAggregator>().InSingletonScope();
        }

        #endregion Methods
    }
}