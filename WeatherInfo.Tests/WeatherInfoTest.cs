using System;
using Xunit;

namespace WeatherInfo.Tests
{
    public class WeatherInfoTests
    {
        [Fact]
        public void GetUrl_Given_MapBoxUrlBase_Should_Return_UrlBase()
        {
            MapBoxConfiguration config = new MapBoxConfiguration();
            var actual = config.GetUrl();
            Assert.Equal("https://api.mapbox.com/geocoding/v5/", actual);

        }
        
        
        [Fact]
        public void GetUrl_Given_OpenWeatherUrlBase_Should_Return_UrlBase()
        {
            OpenWeatherConfiguration config = new OpenWeatherConfiguration();
            var actual = config.GetUrl();
            Assert.Equal("https://api.openweathermap.org/data/2.5/weather?lat=", actual);

        }
    }
}
