using CoffeeMachine.Infrastructure.Repositories;
using CoffeeMachine_API.Controllers;
using CoffeeMachine_App.Services;
using CoffeeMachine_Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Coffee_Infrastructure_Test.Service
{
    public class CoffeeService_Test
    {
        [Fact]
        public async Task BrewCoffee_Temperature_Greater_Than_30()
        {
            var mockWeatherService = new Mock<IWeatherService>();
            mockWeatherService.Setup(service => service.GetCurrentTemperature())
                              .ReturnsAsync(32); // Temperature greater than 30°C

            var coffeeService = new CoffeeService(mockWeatherService.Object);

            // Act
            var response = await coffeeService.BrewCoffee();

            // Assert
            Assert.Equal((int)HttpStatusCode.OK, response.StatusCode);
            Assert.Equal("Your refreshing iced coffee is ready", response.Message);

        }

        [Fact]
        public async Task BrewCoffee_Temperature_Less_Than_30()
        {
            // Arrange
            var mockWeatherService = new Mock<IWeatherService>();
            mockWeatherService.Setup(service => service.GetCurrentTemperature())
                              .ReturnsAsync(25); // Temperature less than 30°C

            var coffeeService = new CoffeeService(mockWeatherService.Object);

            // Act
            var response = await coffeeService.BrewCoffee();

            // Assert
            Assert.Equal(0, response.StatusCode);
            Assert.Equal("coffee not ready", response.Message);
        }

    }
}
