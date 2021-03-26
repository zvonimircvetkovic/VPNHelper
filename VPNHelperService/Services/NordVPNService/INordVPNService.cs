using System.Collections.Generic;
using System.Threading.Tasks;
using VPNHelperCommon.Models;
using VPNHelperLibrary.Models;

namespace VPNHelperService.Services
{
    public interface INordVPNService
    {
        Task<bool> GetServers(CountryModel country);
    }
}