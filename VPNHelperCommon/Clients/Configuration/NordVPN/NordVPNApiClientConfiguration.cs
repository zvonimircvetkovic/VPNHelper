using System;

namespace VPNHelperCommon.Clients.Configuration
{
    /// <summary>
    /// The NordVPN api client configuration.
    /// </summary>
    public class NordVPNApiClientConfiguration : INordVPNApiClientConfiguration
    {

        public NordVPNApiClientConfiguration()
        {
        }

        public string ApiKey
        {
            get
            {
                return "apiKey";
            }
        }

        public string ApiKeyHeaderName
        {
            get
            {
                return "ApiKeyHeaderName";
            }
        }

        public string ApiUrl
        {
            get
            {
                return "https://api.nordvpn.com";
            }
        }

        public string StagingApiUrl
        {
            get
            {
                return "apiUrl";
            }
        }

        public string ContentType
        {
            get
            {
                return "application/json";
            }
        }

        public TimeSpan Timeout
        {
            get
            {
                return TimeSpan.FromSeconds(60);
            }
        }

    }
}
