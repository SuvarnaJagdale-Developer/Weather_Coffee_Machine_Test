using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMachine_App.Services
{
    public interface IWeatherService
    {
        Task<double> GetCurrentTemperature();
    }
}
