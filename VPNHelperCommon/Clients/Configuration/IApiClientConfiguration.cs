using System;

namespace VPNHelperCommon.Clients.Configuration
{
    public interface IApiClientConfiguration
    {
        string ApiKey { get; }

        string ApiKeyHeaderName { get; }

        string ApiUrl { get; }

        string ContentType { get; }

        string StagingApiUrl { get; }

        TimeSpan Timeout { get; }
    }
}