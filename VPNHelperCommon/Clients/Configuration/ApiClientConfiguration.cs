using System;

namespace VPNHelperCommon.Clients.Configuration
{
    /// <summary>
    /// The API client configuration.
    /// <seealso cref="IApiClientConfiguration"/>
    /// </summary>
    public class ApiClientConfiguration : IApiClientConfiguration
    {
        public string ApiKey { get; set; }

        public string ApiKeyHeaderName { get; set; }

        public string ApiUrl { get; set; }

        public string StagingApiUrl { get; set; }

        public string ContentType { get; set; }

        public TimeSpan Timeout { get; set; }
    }
}
