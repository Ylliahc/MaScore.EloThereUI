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
        /// <typeparam name="T"></typeparam>
        /// <returns>Http response message.</returns>
        public async Task<HttpResponseMessage> PostAsync<T>(string endpoint, T body)
            where T : class
        {
            if(body == null)
                throw new System.ArgumentNullException(nameof(body));
            string bodySerialized = JsonConvert.SerializeObject(body);
            StringContent bodyContent = new StringContent(
                content: bodySerialized,
                encoding: Encoding.UTF8);
            
            var response = await Client.PostAsync(endpoint, bodyContent);
            response.EnsureSuccessStatusCode();
            return response;
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
    }
}