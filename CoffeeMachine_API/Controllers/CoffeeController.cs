using CoffeeMachine_App.Services;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeMachine_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CoffeeController : ControllerBase
    {
        private readonly ICoffeeService _coffeeService;

        public CoffeeController(ICoffeeService coffeeService)
        {
            _coffeeService = coffeeService;
        }
        [HttpGet("brew-coffee")]
        public async Task<IActionResult> BrewCoffee()
        {
            var response = await _coffeeService.BrewCoffee();
            return StatusCode(response.StatusCode, response);
        }

    }
}
