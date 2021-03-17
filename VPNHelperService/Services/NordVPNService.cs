using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VPNHelperService.Services
{
    public class NordVPNService : INordVPNService
    {
        private List<string> Servers = new List<string>()
        {
            "nl1.nordvpn.com",
            "nl2.nordvpn.com",
            "cro1.nordvpn.com",
            "us1.nordvpn.com",
            "us2.nordvpn.com",
            "us3.nordvpn.com",
            "us4.nordvpn.com",
            "nl3.nordvpn.com",
            "cro2.nordvpn.com"
        };

        public async Task<IEnumerable<string>> GetServers(string country)
        {
            if (Servers.Any(x => x.ToLowerInvariant().Contains(country.ToLowerInvariant())))
            {
                return Servers.Where(x => x.ToLowerInvariant().Contains(country.ToLowerInvariant()));
            }
            return null;
        }
    }
}
