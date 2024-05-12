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

namespace Coffee_Api_Test.Controllers
{
    public class CoffeeController_Test
    {

        [Fact]
        public async Task BrewCoffee_Returns_OK_With_Message()
        {
            // Arrange
            var mockCoffeeService = new Mock<ICoffeeService>();
            mockCoffeeService.Setup(service => service.BrewCoffee())
                             .ReturnsAsync(new CoffeeResponse { StatusCode = (int)HttpStatusCode.OK, Message = "Your refreshing iced coffee is ready" });

            var controller = new CoffeeController(mockCoffeeService.Object);

            // Act
            var result = await controller.BrewCoffee();

            // Assert
            var statusCodeResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal((int)HttpStatusCode.OK, statusCodeResult.StatusCode);
            Assert.Equal("Your refreshing iced coffee is ready", (statusCodeResult.Value as CoffeeResponse)?.Message);
        }

        [Fact]
        public async Task BrewCoffee_Returns_Service_Unavailable_With_Empty_Response_Body()
        {
            // Arrange
            var mockCoffeeService = new Mock<ICoffeeService>();
            mockCoffeeService.Setup(service => service.BrewCoffee())
                             .ReturnsAsync(new CoffeeResponse { StatusCode = (int)HttpStatusCode.ServiceUnavailable });

            var controller = new CoffeeController(mockCoffeeService.Object);

            // Act
            var result = await controller.BrewCoffee();

            // Assert
            var statusCodeResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal((int)HttpStatusCode.ServiceUnavailable, statusCodeResult.StatusCode);
            Assert.Null((statusCodeResult.Value as CoffeeResponse)?.Message); // Empty response body
        }
    }
}
