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

        public BindableCollection<VPNHelperCommon.Models.IResult> Servers { get; set; }

        public string ResultText { get; set; }

        public Visibility Visibility { get; set; }

        private CountryModel selectedCountry;

        public ShellViewModel(INordVPNService nordVPNService)
        {
            NordVPNService = nordVPNService;
        }

        protected override async void OnInitialize()
        {
            base.OnInitialize();

            DataAccess da = new DataAccess();
            Countries = new BindableCollection<CountryModel>(await da.GetCountriesAsync());
            NotifyOfPropertyChange(() => Countries);
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
                    UpdateListVisibility(true);

                    UpdateResultText("Top 10 results based on load:");

                    Servers = new BindableCollection<VPNHelperCommon.Models.IResult>(result);
                    NotifyOfPropertyChange(() => Servers);
                }
                else
                {
                    UpdateListVisibility(false);

                    UpdateResultText("No servers found.");
                }
            }
            else
            {
                UpdateListVisibility(false);

                UpdateResultText("Please select a country.");
            }
        }

        private void UpdateResultText(string text)
        {
            ResultText = text;
            NotifyOfPropertyChange(() => ResultText);
        }

        private void UpdateListVisibility(bool visible)
        {
            Visibility = visible ? Visibility.Visible : Visibility.Hidden;
            NotifyOfPropertyChange(() => Visibility);
        }
    }
}
