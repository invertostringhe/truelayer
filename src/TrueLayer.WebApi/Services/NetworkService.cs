using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using TrueLayer.WebApi.Exceptions;
using TrueLayer.WebApi.Interfaces;

namespace TrueLayer.WebApi.Services
{
    public class NetworkService : INetworkService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public NetworkService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<T> GetData<T>(string url)
        {
            var client = _httpClientFactory.CreateClient();

            using var response = await client.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                throw new APIErrorException(response.StatusCode);
            }

            var jsonResult = await ParseJson<T>(response.Content);

            return jsonResult;
        }

        public async Task<T> PostData<T>(string url, object requestData)
        {
            var client = _httpClientFactory.CreateClient();

            var httpContent = GetJsonContent(requestData);

            using var response = await client.PostAsync(url, httpContent);

            if (!response.IsSuccessStatusCode)
            {
                throw new APIErrorException(response.StatusCode);
            }

            var jsonResult = await ParseJson<T>(response.Content);

            return jsonResult;
        }

        private async Task<T> ParseJson<T>(HttpContent response)
        {
            using var content = await response.ReadAsStreamAsync();

            var data = await JsonSerializer.DeserializeAsync<T>(content);

            return data;
        }

        private StringContent GetJsonContent(object source)
        {
            if (source == null) throw new ArgumentNullException((nameof(source)));

            var jsonString = JsonSerializer.Serialize(source);

            return new StringContent(
                jsonString,
                System.Text.Encoding.Default,
                "application/json"
            );
        }
    }
}
