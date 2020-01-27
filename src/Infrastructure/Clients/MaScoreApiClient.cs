using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using MaScore.EloThereUI.Infrastructure.Configurations;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace MaScore.EloThereUI.Infrastructure.Clients
{
    public class MaScoreApiClient
    {
        public HttpClient Client { get; }
        private readonly MaScoreClientConfiguration _maScoreClientConfiguration;

        public MaScoreApiClient(
            HttpClient httpClient,
            IOptions<MaScoreClientConfiguration> maScoreClientConfiguration)
        {
            Client = httpClient;
            _maScoreClientConfiguration = maScoreClientConfiguration.Value;

            ConfigureClient();
        }

        /// <summary>
        /// Configure the HttpClient
        /// </summary>
        private void ConfigureClient()
        {
            Client.BaseAddress = new System.Uri(_maScoreClientConfiguration.Url);
        }

        /// <summary>
        /// Handle generics processes for a post request
        /// </summary>
        /// <param name="endpoint">Endpoint to use/contact</param>
        /// <param name="body">Body object</param>
        /// <typeparam name="TInput">Class in input</typeparam>
        /// <returns>Http response message.</returns>
        public async Task<HttpResponseMessage> PostAsync<TInput>(string endpoint, TInput body)
            where TInput : class
        {
            if (string.IsNullOrWhiteSpace(endpoint))
            {
                throw new System.ArgumentException("message", nameof(endpoint));
            }

            if (body == null)
                throw new System.ArgumentNullException(nameof(body));
            
            var bodyContent = GetStringContent(body);
            
            var response = await Client.PostAsync(endpoint, bodyContent);
            response.EnsureSuccessStatusCode();
            return response;
        }

        /// <summary>
        /// Handle generics processes for a post request
        /// </summary>
        /// <param name="endpoint"></param>
        /// <param name="body"></param>
        /// <typeparam name="TInput">Class in input</typeparam>
        /// <typeparam name="TOutput">Class in output</typeparam>
        /// <returns></returns>
        public async Task<TOutput> PostAsync<TInput,TOutput>(string endpoint, TInput body)
            where TInput : class
        {
            var response = await PostAsync<TInput>(endpoint, body);
            return await DeserializeObject<TOutput>(response);
        }

        /// <summary>
        /// Handke generics processes for a get request
        /// </summary>
        /// <param name="url"></param>
        /// <returns>Http response message.</returns>
        public async Task<HttpResponseMessage> GetAsync(string url)
        {
            var response = await Client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            return response;
        }

        /// <summary>
        /// Handke generics processes for a get request and deserialize the result
        /// </summary>
        /// <param name="url"></param>
        /// <returns>Http response message.</returns>
        public async Task<T> GetAsync<T>(string url)
        {
            var response = await GetAsync(url);
            return await DeserializeObject<T>(response);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="endpoint"></param>
        /// <param name="body"></param>
        /// <typeparam name="TInput"></typeparam>
        /// <returns></returns>
        public async Task<HttpResponseMessage> PutAsync<TInput>(string endpoint,TInput body)
            where TInput : class
        {
            if (string.IsNullOrWhiteSpace(endpoint))
            {
                throw new System.ArgumentException("message", nameof(endpoint));
            }

            if (body is null)
            {
                throw new System.ArgumentNullException(nameof(body));
            }

            var bodyContent = GetStringContent(body);
            return await Client.PutAsync(endpoint, bodyContent);
        }

        public async Task<HttpResponseMessage> PutAsync(string request)
        {
            if (string.IsNullOrWhiteSpace(request))
            {
                throw new System.ArgumentException("message", nameof(request));
            }
            //TODO : see use of HttpRequestMessage and Client.SendAsync
            return await Client.PutAsync(request, new StringContent(string.Empty));
        }

        /// <summary>
        /// Deserialize content of a http response
        /// </summary>
        /// <param name="httpResponseMessage"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        private async Task<T> DeserializeObject<T>(HttpResponseMessage httpResponseMessage)
        {
            var responseContent = await httpResponseMessage.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(responseContent);
        }
        
        /// <summary>
        /// Create a string content from an object
        /// </summary>
        /// <param name="body">Object to serialize.</param>
        /// <typeparam name="TInput"></typeparam>
        /// <returns>Object serialized</returns>
        private StringContent GetStringContent<TInput>(TInput body)
            where TInput : class
        {
            string bodySerialized = JsonConvert.SerializeObject(body);
            return new StringContent(
                content: bodySerialized,
                encoding: Encoding.UTF8);
        }
    }
}