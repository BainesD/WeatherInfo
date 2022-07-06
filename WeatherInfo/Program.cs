using System;
using System.Collections.Generic;
using System.Linq;
namespace WeatherInfo
{
    internal class Program
    {
        private static OpenWeatherClient _openWClient = new OpenWeatherClient(new OpenWeatherConfiguration());
        private static MapBoxClient _mapBoxClient = new MapBoxClient(new MapBoxConfiguration());
        static void Main(string[] args)
        {

            Console.WriteLine("What city would you like to see the weather for?");
            var place = Console.ReadLine();

            //below place to test a specific place
            //var place = "Birmingham, AL";

            var mapBoxResponse = _mapBoxClient.GetInformationByPlaceAsync(place).Result;

            var coord = mapBoxResponse.features.Select(x => x.geometry.coordinates);
            List<float> returnedCoords = new List<float>();
            foreach (var coordinate in coord)
            {
                for (int i = 0; i < coordinate.Length; i++)
                {
                    returnedCoords.Add(coordinate[i]);
                }
            }
            string lng = Math.Round(returnedCoords[0], 0).ToString();
            string lat = Math.Round(returnedCoords[1], 0).ToString();

            var openWeatherResponse = _openWClient.GetInformationByPlaceAsync(lat, lng).Result;

            var weatherDescription = openWeatherResponse.weather.Select(x => x.description).First().ToString();
            var currentTempFahr = openWeatherResponse.main.temp;
            var tempMaxFahr = openWeatherResponse.main.temp_max;
            var tempMinFahr = openWeatherResponse.main.temp_min;
            var placeName = mapBoxResponse.features.Select(x => x.place_name).First();
            var humidity = openWeatherResponse.main.humidity;
            var windSpeed = openWeatherResponse.wind.speed;
            var windDir = WindDirectionParser(openWeatherResponse.wind.deg);


            Console.WriteLine($"The weateher for {placeName} is {weatherDescription}." +
                $"\nThe current temperature in {placeName} is {currentTempFahr} degrees fahrenheit. \nThe high for today is {tempMaxFahr} degrees fahrenheit," +
                $"\nand the low for today is {tempMinFahr} degrees farhenheit, \nwith {humidity} % humidity and wind blowing from the {windDir} direction.");

        }
        //public static double ConvertKelvinToFahrenheit(float tempKelvin)
        //{
        //    var tempFahrenheit = Convert.ToDouble(Math.Round(((tempKelvin-273.15)*1.8+32),2));
        //    return tempFahrenheit;
        //}
        public static string WindDirectionParser(int windDeg)
        {
            if (windDeg > 348.75 || windDeg < 11.25)
                return "Northerly";
            if (windDeg < 34 && windDeg > 11.25)
                return "North North-East";
            if (windDeg < 56.25 && windDeg > 34)
                return "North-Easterly";
            if (windDeg < 78.75 && windDeg > 56.25)
                return "East North-East";
            if (windDeg < 101.25 && windDeg > 78.75)
                return "Easterly";
            if (windDeg < 123.75 && windDeg > 101.25)
                return "East South-East";
            if (windDeg < 146.25 && windDeg > 123.75)
                return "South-Easterly";
            if (windDeg < 168.75 && windDeg > 146.25)
                return "South South-East";
            if (windDeg < 191.25 && windDeg > 168.75)
                return "South";
            if (windDeg < 213.75 && windDeg > 191.25)
                return "South South-West";
            if (windDeg < 236.25 && windDeg > 213.75)
                return "South-Westerly";
            if (windDeg < 258.75 && windDeg > 236.25)
                return "West South-West";
            if (windDeg < 281.25 && windDeg > 258.75)
                return "Westerly";
            if (windDeg < 303.75 && windDeg > 281.25)
                return "West North-West";
            if (windDeg < 326.25 && windDeg > 303.75)
                return "North-Westerly";
            if (windDeg < 348.75 && windDeg > 326.25)
                return "North North-West";
            return "unkown";
        }
    }

}
