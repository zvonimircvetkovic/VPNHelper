using System.Collections.Generic;
using System.Threading.Tasks;

namespace VPNHelperService.Services
{
    public interface INordVPNService
    {
        Task<IEnumerable<string>> GetServers(string country);
    }
}