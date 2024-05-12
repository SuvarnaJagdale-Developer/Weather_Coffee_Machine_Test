using CoffeeMachine_Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMachine_App.Services
{
    public interface ICoffeeService
    {
        Task<CoffeeResponse> BrewCoffee();
    }
}
