using System.Collections.Generic;
using System.Threading.Tasks;
using VPNHelperCommon.Models;

namespace VPNHelperService.Services
{
    public interface INordVPNService
    {
        Task<IEnumerable<IResult>> GetServers(string country);
    }
}