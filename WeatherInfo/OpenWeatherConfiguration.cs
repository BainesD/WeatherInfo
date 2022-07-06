using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace WeatherInfo
{
    public class OpenWeatherConfiguration
    {
        
        
        private const string _apiKey = "apikey";
        private string _configSection = "OpenWeatherAPI";
        private const string _appSettings = "appsettings.json";
        private const string _urlBase = "urlbase";
        public string GetAPIKey() => GetSection(_apiKey);

        public string GetUrl() => GetSection(_urlBase);



        private string GetSection(string section) => GetConfigurationString($"{_configSection}:{section}");

        private string GetConfigurationString(string configSection) => GetConfigurationRoot()[configSection];

        private IConfigurationRoot GetConfigurationRoot() => new ConfigurationBuilder().AddJsonFile(_appSettings).Build();

        

    }
}



