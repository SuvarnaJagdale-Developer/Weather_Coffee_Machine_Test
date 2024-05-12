using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMachine_Domain.Models
{
    public class CoffeeResponse
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
       //public string Prepared { get; set; }
    }
}
