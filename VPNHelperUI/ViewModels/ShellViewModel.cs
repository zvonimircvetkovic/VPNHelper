using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using VPNHelperLibrary;
using VPNHelperLibrary.Models;

namespace VPNHelperUI.ViewModels
{
    public class ShellViewModel : Screen
    {
        public BindableCollection<CountryModel> Countries { get; set; }

        private CountryModel selectedCountry;

        public ShellViewModel()
        {
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

        public void Search()
        {
            if (SelectedCountry != null)
            {
                MessageBox.Show(SelectedCountry.Name);
            }
            else
            {
                MessageBox.Show("Please select a country.");
            }
        }
    }
}
