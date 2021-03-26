using Caliburn.Micro;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using VPNHelperService.Services;
using VPNHelperUI.ViewModels;

namespace VPNHelperUI
{
    public class Bootstrapper : BootstrapperBase
    {
        private IKernel Kernel;

        public Bootstrapper()
        {
            Initialize();
        }

        protected override void Configure()
        {
            Kernel = new StandardKernel(new VPNHelperService.DIModule(), new VPNHelperCommon.DIModule(), new VPNHelperUI.DIModule());
        }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewFor<ShellViewModel>();
        }

        protected override object GetInstance(Type service, string key)
        {
            return Kernel.Get(service, key);
        }

        protected override IEnumerable<object> GetAllInstances(Type service)
        {
            return Kernel.GetAll(service);
        }

        protected override void OnExit(object sender, EventArgs e)
        {
            Kernel.Dispose();
            base.OnExit(sender, e);
        }
    }
}
