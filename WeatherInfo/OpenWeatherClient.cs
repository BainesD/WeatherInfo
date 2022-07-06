using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace WeatherInfo
{
    internal class OpenWeatherClient
    {

        public OpenWeatherClient(OpenWeatherConfiguration config)
        {
            _url = config.GetUrl();
            _apiKey = config.GetAPIKey();
        }
        private string _url;
        private string _apiKey;
        private HttpClient _client = new HttpClient();
        private string GetURLToSearch(string lat, string lon) => $"{_url}{lat}&lon={lon}&appid={_apiKey}&units=imperial";
        public async Task<OpenWeatherResponse> GetInformationByPlaceAsync(string lat, string lon)
        {

            var response = await _client.GetStringAsync(GetURLToSearch(lat, lon));

            return response == null ? null! : JsonSerializer.Deserialize<OpenWeatherResponse>(response)!;
        }

    }
}
