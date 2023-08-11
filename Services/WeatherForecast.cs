using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class WeatherForecast : IWeatherForecast
    {
        public string GetWeather()
        {
            return "Raining...";
        }
    }
}
