using VPNHelperCommon.Clients.Configuration;
using VPNHelperCommon.Formatters;

namespace VPNHelperCommon.Clients
{
    /// <summary>
    /// The odie api client.
    /// <seealso cref="JsonApiClient"/>
    /// <seealso cref="INordVPNApiClient"/>
    /// </summary>
    public class NordVPNApiClient : JsonApiClient, INordVPNApiClient
    {
        /// <summary>
        /// Initializes new instance of <see cref="NordVPNApiClient"/> class.
        /// </summary>
        /// <param name="formatter">The formatter.</param>
        /// <param name="clientConfiguration">The client configuration.</param>
        public NordVPNApiClient(JsonFormatter formatter, INordVPNApiClientConfiguration clientConfiguration)
            : base(formatter, clientConfiguration)
        {
        }
    }
}
