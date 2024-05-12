using CoffeeMachine_App.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CoffeeMachine.Infrastructure.Repositories
{
    public class WeatherService : IWeatherService
    {
        private readonly HttpClient _httpClient;
       // private readonly string _apiKey;
        private const string WeatherApiUrl = "https://openweathermap.org/api";
        public WeatherService(HttpClient httpClient)
        {
          //  _apiKey = apiKey;
            _httpClient = httpClient;
        }
        public async Task<double> GetCurrentTemperature()
        {
            try
            {
               
                var response=await _httpClient.GetAsync(WeatherApiUrl);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                   

                    //var weatherData = ParseWeatherData(content);
                    //return weatherData.Temperature;
                    //  Dummy temperature for example
                }
                return 32;
                
            }
            catch (Exception ex)
            {
                // Log or handle the exception
                throw new Exception("Failed to fetch weather data", ex);
            }
        }


    }
}
