using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using VPNHelperCommon.Clients.Configuration;
using VPNHelperCommon.Formatters;

namespace VPNHelperCommon.Clients
{
    /// <summary>
    /// Json API client class.
    /// <seealso cref="IJsonApiClient"/>
    /// </summary>
    public class JsonApiClient : IJsonApiClient
    {
        #region Properties

        /// <summary>
        /// The Http client.
        /// </summary>
        protected HttpClient Client { get; }

        /// <summary>
        /// The api client configuration.
        /// </summary>
        protected IApiClientConfiguration ClientConfiguration { get; }

        /// <summary>
        /// The JSON formatter.
        /// </summary>
        protected JsonFormatter Formatter { get; }

        #endregion Properties

        #region Constructor

        /// <summary>
        /// Initializes new instance of <see cref="JsonApiClient"/> class.
        /// </summary>
        /// <param name="formatter">The formatter.</param>
        /// <param name="clientConfiguration">The client configuration.</param>
        public JsonApiClient(JsonFormatter formatter, IApiClientConfiguration clientConfiguration)
        {
            this.Formatter = formatter;
            this.ClientConfiguration = clientConfiguration;

            var client = new HttpClient();
            InitializeClient(client);
            this.Client = client;
        }

        #endregion Constructor

        #region Methods

        /// <summary>
        /// Asynchronously deletes the object from the system.
        /// </summary>
        /// <param name="requestUri">Request URI.</param>
        /// <param name="queryParameters">Query parameters.</param>
        /// <returns>True if object is deleted, false otherwise.</returns>
        public virtual Task<IClientResponse<T>> DeleteAsync<T>(string requestUri, string queryParameters = "")
        {
            return DeleteAsync<T>(requestUri, new CancellationToken(), queryParameters);
        }

        /// <summary>
        /// Asynchronously deletes the object from the system.
        /// </summary>
        /// <param name="requestUri">Request URI.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <param name="queryParameters">Query parameters.</param>
        /// <returns>True if object is deleted, false otherwise.</returns>
        public virtual async Task<IClientResponse<T>> DeleteAsync<T>(string requestUri, CancellationToken cancellationToken, string queryParameters = "")
        {
            HttpClient client = Client;
            {
                var request = new HttpRequestMessage(HttpMethod.Delete, $"{requestUri}{queryParameters}");
                //InitializeClientAuthorization(request);

                var response = await client.SendAsync(request, cancellationToken);
                return await CreateResponseAsync<T>(response);
            }
        }

        /// <summary>
        /// Gets the API URL.
        /// </summary>
        /// <param name="relativeUrl">The relative URL.</param>
        /// <returns></returns>
        public virtual string GetApiUrl(string relativeUrl)
        {
            return $"{ClientConfiguration.ApiUrl}/{relativeUrl}";
        }

        /// <summary>
        /// Gets the Staging API URL.
        /// </summary>
        /// <param name="relativeUrl">The relative URL.</param>
        /// <returns></returns>
        public virtual string GetStagingApiUrl(string relativeUrl)
        {
            return $"{ClientConfiguration.StagingApiUrl}/{relativeUrl}";
        }

        /// <summary>
        /// Asynchronously gets the <typeparamref name="T" /> from the system.
        /// </summary>
        /// <typeparam name="T">Object type.</typeparam>
        /// <param name="requestUri">Request URI.</param>
        /// <returns><typeparamref name="T" /> .</returns>
        public virtual Task<IClientResponse<T>> GetAsync<T>(string requestUri, string queryParameters = "")
        {
            return GetAsync<T>(requestUri, new CancellationToken(), queryParameters);
        }

        /// <summary>
        /// Asynchronously gets the <typeparamref name="T" /> from the system.
        /// </summary>
        /// <typeparam name="T">Object type.</typeparam>
        /// <param name="requestUri">Request URI.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><typeparamref name="T" /> .</returns>
        public virtual async Task<IClientResponse<T>> GetAsync<T>(string requestUri, CancellationToken cancellationToken, string queryParameters = "")
        {
            HttpClient client = Client;
            {
                var request = new HttpRequestMessage(HttpMethod.Get, $"{requestUri}{queryParameters}");
                //InitializeClientAuthorization(request);

                var response = await client.SendAsync(request, cancellationToken);
                return await CreateResponseAsync<T>(response);
            }
        }

        /// <summary>
        /// Asynchronously insert the <typeparamref name="T" /> into the system.
        /// </summary>
        /// <typeparam name="T">Resource type.</typeparam>
        /// <param name="requestUri">Request URI.</param>
        /// <param name="content">Resource instance.</param>
        /// <param name="queryParameters">Query parameters.</param>
        /// <returns>Newly created <typeparamref name="T" /> .</returns>
        public virtual Task<IClientResponse<T>> PostAsync<T>(string requestUri, T content, string queryParameters = "")
        {
            return PostAsync<T>(requestUri, content, new CancellationToken(), queryParameters);
        }

        /// <summary>
        /// Asynchronously insert the <typeparamref name="T" /> into the system.
        /// </summary>
        /// <typeparam name="T">Resource type.</typeparam>
        /// <param name="requestUri">Request URI.</param>
        /// <param name="content">Resource instance.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <param name="queryParameters">Query parameters.</param>
        /// <returns>Newly created <typeparamref name="T" /> .</returns>
        public virtual async Task<IClientResponse<T>> PostAsync<T>(string requestUri, T content, CancellationToken cancellationToken, string queryParameters = "")
        {
            HttpClient client = Client;
            {
                var request = new HttpRequestMessage(HttpMethod.Post, $"{requestUri}{queryParameters}");
                if (content != null)
                {
                    request.Content = Formatter.SerializeToHttpContent(content);
                }
                //InitializeClientAuthorization(request);

                var response = await client.SendAsync(request, cancellationToken);
                return await CreateResponseAsync<T>(response);
            }
        }

        /// <summary>
        /// Asynchronously insert the <typeparamref name="TIn" /> into the system.
        /// </summary>
        /// <typeparam name="TIn">The type of the in resource.</typeparam>
        /// <typeparam name="TOut">The type of the out resource.</typeparam>
        /// <param name="requestUri">Request URI.</param>
        /// <param name="content">Resource instance.</param>
        /// <param name="queryParameters">Query parameters.</param>
        /// <returns>Newly created <typeparamref name="TOut" /> .</returns>
        public virtual Task<IClientResponse<TOut>> PostAsync<TIn, TOut>(string requestUri, TIn content, string queryParameters = "")
        {
            return PostAsync<TIn, TOut>(requestUri, content, new CancellationToken(), queryParameters);
        }

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
        public virtual async Task<IClientResponse<TOut>> PostAsync<TIn, TOut>(string requestUri, TIn content, CancellationToken cancellationToken, string queryParameters = "")
        {
            HttpClient client = Client;
            {
                var request = new HttpRequestMessage(HttpMethod.Post, $"{requestUri}{queryParameters}");
                if (content != null)
                {
                    request.Content = Formatter.SerializeToHttpContent(content);
                }
                //InitializeClientAuthorization(request);

                var response = await client.SendAsync(request, cancellationToken);
                return await CreateResponseAsync<TOut>(response);
            }
        }

        /// <summary>
        /// Asynchronously update the <typeparamref name="T" /> in the system.
        /// </summary>
        /// <typeparam name="T">Resource type.</typeparam>
        /// <param name="requestUri">Request URI.</param>
        /// <param name="content">Resource instance.</param>
        /// <param name="queryParameters">Query parameters.</param>
        /// <returns>Updated <typeparamref name="T" /> .</returns>
        public virtual Task<IClientResponse<T>> PutAsync<T>(string requestUri, T content, string queryParameters = "")
        {
            return PutAsync<T>(requestUri, content, new CancellationToken(), queryParameters);
        }

        /// <summary>
        /// Asynchronously update the <typeparamref name="T" /> in the system.
        /// </summary>
        /// <typeparam name="T">Resource type.</typeparam>
        /// <param name="requestUri">Request URI.</param>
        /// <param name="content">Resource instance.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <param name="queryParameters">Query parameters.</param>
        /// <returns>Updated <typeparamref name="T" /> .</returns>
        public virtual async Task<IClientResponse<T>> PutAsync<T>(string requestUri, T content, CancellationToken cancellationToken, string queryParameters = "")
        {
            HttpClient client = Client;
            {
                var request = new HttpRequestMessage(HttpMethod.Put, $"{requestUri}{queryParameters}");
                if (content != null)
                {
                    request.Content = Formatter.SerializeToHttpContent(content);
                }
                //InitializeClientAuthorization(request);

                var response = await client.SendAsync(request, cancellationToken);
                return await CreateResponseAsync<T>(response);
            }
        }

        /// <summary>
        /// Asynchronously update the <typeparamref name="TIn" /> in the system.
        /// </summary>
        /// <typeparam name="TIn">The type of the in resource.</typeparam>
        /// <typeparam name="TOut">The type of the out resource.</typeparam>
        /// <param name="requestUri">Request URI.</param>
        /// <param name="content">Resource instance.</param>
        /// <param name="queryParameters">Query parameters.</param>
        /// <returns><typeparamref name="TOut" /> .</returns>
        public virtual Task<IClientResponse<TOut>> PutAsync<TIn, TOut>(string requestUri, TIn content, string queryParameters = "")
        {
            return PutAsync<TIn, TOut>(requestUri, content, new CancellationToken(), queryParameters);
        }

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
        public virtual async Task<IClientResponse<TOut>> PutAsync<TIn, TOut>(string requestUri, TIn content, CancellationToken cancellationToken, string queryParameters = "")
        {
            HttpClient client = Client;
            {
                var request = new HttpRequestMessage(HttpMethod.Put, $"{requestUri}{queryParameters}");
                if (content != null)
                {
                    request.Content = Formatter.SerializeToHttpContent(content);
                }
                //InitializeClientAuthorization(request);

                var response = await client.SendAsync(request, cancellationToken);
                return await CreateResponseAsync<TOut>(response);
            }
        }

        /// <summary>
        /// Returns deserialized content from response.
        /// </summary>
        /// <typeparam name="T">Resource type.</typeparam>
        /// <param name="response">HTTP response.</param>
        /// <returns><typeparamref name="T" /> Resource.</returns>
        public virtual async Task<T> ReadContentAsync<T>(HttpResponseMessage response)
        {
            if (typeof(T) == typeof(HttpStatusCode))
            {
                return (T)(object)response.StatusCode;
            }

            if (response.Content != null && response.Content.Headers.ContentLength > 0)
            {
                return Formatter.Deserialize<T>(await response.Content.ReadAsStreamAsync());
            }
            else
            {
                return default(T);
            }
        }

        protected virtual async Task<IClientResponse<T>> CreateResponseAsync<T>(HttpResponseMessage response)
        {
            var clientResponse = new ClientResponse<T>();
            clientResponse.StatusCode = response.StatusCode;
            if (!response.IsSuccessStatusCode)
            {
                var content = await ReadContentAsync<object>(response);
                clientResponse.Content = default(T);
                clientResponse.Message = Formatter.Serialize(content);
            }
            else
            {
                clientResponse.Content = await ReadContentAsync<T>(response);
            }

            return clientResponse;
        }

        /// <summary>
        /// Initializes the client.
        /// </summary>
        /// <param name="client">The client.</param>
        protected virtual void InitializeClient(HttpClient client)
        {
            client.Timeout = ClientConfiguration.Timeout;
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue(ClientConfiguration.ContentType));
        }

        /// <summary>
        /// Initializes the client authorization.
        /// </summary>
        /// <param name="request">The request.</param>
        protected virtual void InitializeClientAuthorization(HttpRequestMessage request)
        {
            request.Headers.Add(ClientConfiguration.ApiKeyHeaderName, ClientConfiguration.ApiKey);
        }

        #endregion Methods
    }
}
