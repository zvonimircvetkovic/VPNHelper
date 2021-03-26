using System.Net;

namespace VPNHelperCommon.Clients
{
    public interface IClientResponse<T>
    {

        /// <summary>
        /// Gets or sets content.
        /// </summary>
        T Content { get; set; }

        /// <summary>
        /// Check if response status code is success.
        /// </summary>
        bool IsSuccessStatusCode { get; }

        /// <summary>
        /// Gets or sets message.
        /// </summary>
        string Message { get; set; }

        /// <summary>
        /// Gets or sets status code.
        /// </summary>
        HttpStatusCode StatusCode { get; set; }

    }
}