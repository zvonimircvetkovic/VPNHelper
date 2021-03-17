using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using VPNHelperLibrary;
using VPNHelperLibrary.Models;
using VPNHelperService.Services;

namespace VPNHelperUI.ViewModels
{
    public class ShellViewModel : Conductor<object>
    {
        private INordVPNService NordVPNService { get; }

        public BindableCollection<CountryModel> Countries { get; set; }

        private CountryModel selectedCountry;

        public ShellViewModel(INordVPNService nordVPNService)
        {
            NordVPNService = nordVPNService;

            DataAccess da = new DataAccess();
            Countries = new BindableCollection<CountryModel>(da.GetCountriesAsync().Result);
        }

        public CountryModel SelectedCountry 
        { 
            get { return selectedCountry; } 
            set 
            {
                selectedCountry = value;
                NotifyOfPropertyChange(() => SelectedCountry);
            } 
        }

        public async Task Search()
        {
            if (SelectedCountry != null)
            {
                var result = await NordVPNService.GetServers(SelectedCountry.Abrv);
                if (result != null && result.Any())
                {
                    MessageBox.Show(string.Join(", ", result));
                }
                else
                {
                    MessageBox.Show("No servers found.");
                }
            }
            else
            {
                MessageBox.Show("Please select a country.");
            }
        }
    }
}
