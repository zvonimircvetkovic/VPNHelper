using System.Net;

namespace VPNHelperCommon.Clients
{
    /// <summary>
    /// The client response class.
    /// <seealso cref="IClientResponse{T}"/>
    /// </summary>
    /// <typeparam name="T">Content type.</typeparam>
    public class ClientResponse<T> : IClientResponse<T>
    {

        /// <summary>
        /// Gets or sets content.
        /// </summary>
        public T Content { get; set; }

        /// <summary>
        /// Check if response status code is success.
        /// </summary>
        public bool IsSuccessStatusCode
        {
            get
            {
                return ((int)StatusCode >= 200) && ((int)StatusCode <= 299);
            }
        }

        /// <summary>
        /// Gets or sets message.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets status code.
        /// </summary>
        public HttpStatusCode StatusCode { get; set; }

    }
}
