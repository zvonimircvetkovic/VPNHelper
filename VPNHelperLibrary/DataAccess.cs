using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VPNHelperLibrary.Models;

namespace VPNHelperLibrary
{
    public class DataAccess
    {
        IEnumerable<CountryModel> Countries = new List<CountryModel>
        { 
            new CountryModel { Name = "Croatia", Abrv = "cro" },
            new CountryModel { Name = "United States", Abrv = "us" },
            new CountryModel { Name = "Netherlands", Abrv = "nl" }
        };

        public Task<IEnumerable<CountryModel>> GetCountriesAsync()
        {
            return Task.FromResult(Countries);
        }
    }
}
