using System.Net.Http.Headers;
using System.Text;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using Tami.Pago.Core.ServiceResponses;

namespace Tami.Pago.Core
{
    public class TamiHttpClient : IDisposable
    {
        private readonly HttpClient _client;
        private readonly ILogger _logger;
        public readonly string SecretKey;
        public readonly long MerchantId;
        public readonly long TerminalId;
        public TamiHttpClient(string baseAddress, long merchantId, long terminalId, string secretKey, int timeoutSecond = 30, string defaultMediaType = "application/json", ILogger logger = null)
        {
            this.SecretKey = secretKey;
            this.MerchantId = merchantId;   
            this.TerminalId = terminalId;

            _client = new HttpClient { BaseAddress = new Uri(baseAddress) };
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(defaultMediaType));

            _client.DefaultRequestHeaders.Add("Accept-Language", "tr");
            // HttpClient çağrılarına header parametresi olarak PG-Api-Version ve PG-AUTH-TOKEN ekleniyor.
            _client.DefaultRequestHeaders.Add("PG-Api-Version", "v2");
            _client.DefaultRequestHeaders.Add("PG-Auth-Token", $"{merchantId}:{terminalId}:{CryptoHelper.GetPagoHash(merchantId.ToString() + terminalId.ToString() + secretKey)}");

            _client.Timeout = TimeSpan.FromSeconds(timeoutSecond);
            _logger = logger;
        }

        public async Task<T> GetAsync<T>(string url, string correlationId = null)
        {
            try
            {
                _client.DefaultRequestHeaders.Remove("correlationId");
                _client.DefaultRequestHeaders.Add("correlationId", correlationId ?? Guid.NewGuid().ToString("N"));

                HttpResponseMessage response = await _client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<T>(result);
                }
                else
                {
                    throw new HttpRequestException($"Error: {response.StatusCode}");
                }
            }
            catch (Exception e)
            {
                _logger?.LogError(e, $"GET request to {url} failed.");
                throw;
            }
        }

        public async Task<T> PostAsync<T>(string url, object data, string correlationId = null) where T : ResponseBase
        {
            try
            {
                var jsonSerializerSettings = new JsonSerializerSettings()
                {
                    Converters = { new IsoDateTimeConverter { DateTimeFormat = "yyyy-MM-ddTHH:mm:ss.fff" } },
                    NullValueHandling = NullValueHandling.Ignore,
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                };
                var jsonData = JsonConvert.SerializeObject(data, jsonSerializerSettings);
                var stringContent = AsJson(jsonData);
                _client.DefaultRequestHeaders.Remove("correlationId");
                _client.DefaultRequestHeaders.Add("correlationId", correlationId ?? Guid.NewGuid().ToString("N"));
                HttpResponseMessage response = await _client.PostAsync(url, stringContent);

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    var returnObj = JsonConvert.DeserializeObject<T>(result, new JsonSerializerSettings() { ContractResolver = new CamelCasePropertyNamesContractResolver() });
                    return returnObj;
                }
                else
                {
                    var result = await response.Content.ReadAsStringAsync();
                    throw new HttpRequestException($"Error: {response.StatusCode}, ServiceResult: {result}");
                }
            }
            catch (Exception e)
            {
                _logger?.LogError(e, $"POST request to {url} with data {data} failed.");
                throw;
            }
        }

        public void Dispose()
        {
            _client?.Dispose();
        }

        private static StringContent AsJson(string jsonData) => new (jsonData, Encoding.UTF8, "application/json");
    }
}