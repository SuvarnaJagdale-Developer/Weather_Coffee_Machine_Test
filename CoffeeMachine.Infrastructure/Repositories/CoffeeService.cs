using CoffeeMachine_App.Services;
using CoffeeMachine_Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMachine.Infrastructure.Repositories
{
    public class CoffeeService:ICoffeeService
    {
        private readonly IWeatherService _weatherService;
        public static int getRequestCount = 0;

        public CoffeeService(IWeatherService weatherService)
        {
            _weatherService = weatherService;
        }
        public async Task<CoffeeResponse> BrewCoffee()
        {
            getRequestCount++;

            var temperature = await _weatherService.GetCurrentTemperature();

            var response = new CoffeeResponse();
            //{
            //    StatusCode = (int)HttpStatusCode.OK,
            //    Prepared = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:sszzz")
            //};

            if (temperature > 30)
            {
                response.StatusCode = (int)HttpStatusCode.OK;
              
                response.Message = "Your refreshing iced coffee is ready";
            }
            else
            {
                response.StatusCode = 0;

                response.Message = "coffee not ready";

            }
            if (getRequestCount % 5 == 0)
            {
                response.StatusCode = (int)HttpStatusCode.ServiceUnavailable;
                response.Message = "Service Unavailable";
            }

            if (DateTime.Today.Month == 4 && DateTime.Today.Day == 1)
            {
                response.StatusCode = 418;
                response.Message = "418 I'm a teapot";
            }

            return response;
        }


    }
}
