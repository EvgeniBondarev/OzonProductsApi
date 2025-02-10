using System.Text;
using Newtonsoft.Json;
using OzonProductsApi.Application.OzonApiClient.Interfaces;
using Polly;
using Polly.Retry;
using OzonProductsApi.Application.OzonApiClient.Implementation.Utils;


namespace OzonProductsApi.Application.OzonApiClient.Implementation;

public class OzonApiClient : IOzonApiClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly AsyncRetryPolicy<HttpResponseMessage> _retryPolicy;

        public OzonApiClient(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory ?? throw new ArgumentNullException(nameof(httpClientFactory));
            _retryPolicy = Policy<HttpResponseMessage>
                .Handle<HttpRequestException>()
                .OrResult(response => !response.IsSuccessStatusCode)
                .WaitAndRetryAsync(3, retryAttempt => TimeSpan.FromSeconds(2));
        }

        public async Task<TResponse> SendRequestAsync<TRequest, TResponse>(
            HttpMethod method,
            string endpoint,
            Dictionary<string, string>? headers,
            TRequest payload)
        {
            var client = _httpClientFactory.CreateClient("RetryClient");
            
            
            var request = new HttpRequestMessage(method, endpoint);

            if (headers != null)
            {
                foreach (var header in headers)
                {
                    request.Headers.Add(header.Key, header.Value);
                }
            }

            if (payload != null)
            {
                var jsonBody = JsonConvert.SerializeObject(payload, Converter.Settings);
                request.Content = new StringContent(jsonBody, Encoding.UTF8, "application/json");
            }
            
            HttpResponseMessage response = await _retryPolicy.ExecuteAsync(() => client.SendAsync(request));
            response.EnsureSuccessStatusCode();

            string jsonResponse = await response.Content.ReadAsStringAsync();


            return JsonConvert.DeserializeObject<TResponse>(jsonResponse, Converter.Settings);
        }
    }