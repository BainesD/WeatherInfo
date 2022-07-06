
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace WeatherInfo
{
    internal class MapBoxClient

    {
        public MapBoxClient(MapBoxConfiguration config)
        {
            _url = config.GetUrl();
            _apiKey = config.GetAPIKey();
        }
        private readonly string _url;
        private readonly string _apiKey;
        private readonly HttpClient _client = new HttpClient();

        private string GetURLToSearch(string place) => $"{_url}mapbox.places/{place}.json?access_token={_apiKey}";
        public async Task<MapBoxResponse> GetInformationByPlaceAsync(string place)
        {

            var response = await _client.GetStringAsync(GetURLToSearch(place));

            return response == null ? null! : JsonSerializer.Deserialize<MapBoxResponse>(response)!;
        }
    }
}
