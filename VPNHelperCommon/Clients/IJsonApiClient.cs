using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace VPNHelperCommon.Clients
{
    public interface IJsonApiClient
    {

        /// <summary>
        /// Asynchronously deletes the object from the system.
        /// </summary>
        /// <param name="requestUri">Request URI.</param>
        /// <param name="queryParameters">Query parameters.</param>
        /// <returns>True if object is deleted, false otherwise.</returns>
        Task<IClientResponse<T>> DeleteAsync<T>(string requestUri, string queryParameters = "");

        /// <summary>
        /// Asynchronously deletes the object from the system.
        /// </summary>
        /// <param name="requestUri">Request URI.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <param name="queryParameters">Query parameters.</param>
        /// <returns>True if object is deleted, false otherwise.</returns>
        Task<IClientResponse<T>> DeleteAsync<T>(string requestUri, CancellationToken cancellationToken, string queryParameters = "");

        /// <summary>
        /// Gets the API URL.
        /// </summary>
        /// <param name="relativeUrl">The relative URL.</param>
        /// <returns></returns>
        string GetApiUrl(string relativeUrl);

        /// <summary>
        /// Gets the Staging API URL.
        /// </summary>
        /// <param name="relativeUrl">The relative URL.</param>
        /// <returns></returns>
        string GetStagingApiUrl(string relativeUrl);

        /// <summary>
        /// Asynchronously gets the <typeparamref name="T" /> from the system.
        /// </summary>
        /// <typeparam name="T">Object type.</typeparam>
        /// <param name="requestUri">Request URI.</param>
        /// <param name="queryParameters">Query parameters.</param>
        /// <returns><typeparamref name="T" /> .</returns>
        Task<IClientResponse<T>> GetAsync<T>(string requestUri, string queryParameters = "");

        /// <summary>
        /// Asynchronously gets the <typeparamref name="T" /> from the system.
        /// </summary>
        /// <typeparam name="T">Object type.</typeparam>
        /// <param name="requestUri">Request URI.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <param name="queryParameters">Query parameters.</param>
        /// <returns><typeparamref name="T" /> .</returns>
        Task<IClientResponse<T>> GetAsync<T>(string requestUri, CancellationToken cancellationToken, string queryParameters = "");

        /// <summary>
        /// Asynchronously insert the <typeparamref name="T" /> into the system.
        /// </summary>
        /// <typeparam name="T">Resource type.</typeparam>
        /// <param name="requestUri">Request URI.</param>
        /// <param name="content">Resource instance.</param>
        /// <param name="queryParameters">Query parameters.</param>
        /// <returns>Newly created <typeparamref name="T" /> .</returns>
        Task<IClientResponse<T>> PostAsync<T>(string requestUri, T content, string queryParameters = "");

        /// <summary>
        /// Asynchronously insert the <typeparamref name="T" /> into the system.
        /// </summary>
        /// <typeparam name="T">Resource type.</typeparam>
        /// <param name="requestUri">Request URI.</param>
        /// <param name="content">Resource instance.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <param name="queryParameters">Query parameters.</param>
        /// <returns>Newly created <typeparamref name="T" /> .</returns>
        Task<IClientResponse<T>> PostAsync<T>(string requestUri, T content, CancellationToken cancellationToken, string queryParameters = "");

        /// <summary>
        /// Asynchronously insert the <typeparamref name="TIn" /> into the system.
        /// </summary>
        /// <typeparam name="TIn">The type of the in resource.</typeparam>
        /// <typeparam name="TOut">The type of the out resource.</typeparam>
        /// <param name="requestUri">Request URI.</param>
        /// <param name="content">Resource instance.</param>
        /// <param name="queryParameters">Query parameters.</param>
        /// <returns>Newly created <typeparamref name="TOut" /> .</returns>
        Task<IClientResponse<TOut>> PostAsync<TIn, TOut>(string requestUri, TIn content, string queryParameters = "");

        /// <summary>
        /// Asynchronously insert the <typeparamref name="TIn" /> into the system.
        /// </summary>
        /// <typeparam name="TIn">The type of the in resource.</typeparam>
        /// <typeparam name="TOut">The type of the out resource.</typeparam>
        /// <param name="requestUri">Request URI.</param>
        /// <param name="content">Resource instance.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <param name="queryParameters">Query parameters.</param>
        /// <returns>Newly created <typeparamref name="TOut" /> .</returns>
        Task<IClientResponse<TOut>> PostAsync<TIn, TOut>(string requestUri, TIn content, CancellationToken cancellationToken, string queryParameters = "");

        /// <summary>
        /// Asynchronously update the <typeparamref name="T" /> in the system.
        /// </summary>
        /// <typeparam name="T">Resource type.</typeparam>
        /// <param name="requestUri">Request URI.</param>
        /// <param name="content">Resource instance.</param>
        /// <param name="queryParameters">Query parameters.</param>
        /// <returns>Updated <typeparamref name="T" /> .</returns>
        Task<IClientResponse<T>> PutAsync<T>(string requestUri, T content, string queryParameters = "");

        /// <summary>
        /// Asynchronously update the <typeparamref name="T" /> in the system.
        /// </summary>
        /// <typeparam name="T">Resource type.</typeparam>
        /// <param name="requestUri">Request URI.</param>
        /// <param name="content">Resource instance.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <param name="queryParameters">Query parameters.</param>
        /// <returns>Updated <typeparamref name="T" /> .</returns>
        Task<IClientResponse<T>> PutAsync<T>(string requestUri, T content, CancellationToken cancellationToken, string queryParameters = "");

        /// <summary>
        /// Asynchronously update the <typeparamref name="TIn" /> in the system.
        /// </summary>
        /// <typeparam name="TIn">The type of the in resource.</typeparam>
        /// <typeparam name="TOut">The type of the out resource.</typeparam>
        /// <param name="requestUri">Request URI.</param>
        /// <param name="content">Resource instance.</param>
        /// <param name="queryParameters">Query parameters.</param>
        /// <returns><typeparamref name="TOut" /> .</returns>
        Task<IClientResponse<TOut>> PutAsync<TIn, TOut>(string requestUri, TIn content, string queryParameters = "");

        /// <summary>
        /// Asynchronously update the <typeparamref name="TIn" /> in the system.
        /// </summary>
        /// <typeparam name="TIn">The type of the in resource.</typeparam>
        /// <typeparam name="TOut">The type of the out resource.</typeparam>
        /// <param name="requestUri">Request URI.</param>
        /// <param name="content">Resource instance.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <param name="queryParameters">Query parameters.</param>
        /// <returns><typeparamref name="TOut" /> .</returns>
        Task<IClientResponse<TOut>> PutAsync<TIn, TOut>(string requestUri, TIn content, CancellationToken cancellationToken, string queryParameters = "");

        /// <summary>
        /// Returns deserialized content from response.
        /// </summary>
        /// <typeparam name="T">Resource type.</typeparam>
        /// <param name="response">HTTP response.</param>
        /// <returns><typeparamref name="T" /> Resource.</returns>
        Task<T> ReadContentAsync<T>(HttpResponseMessage response);

    }
}