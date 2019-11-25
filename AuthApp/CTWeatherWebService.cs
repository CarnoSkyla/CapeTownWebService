using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WeatherServiceLibrary.Models;
    

namespace WeatherServiceLibrary
{
    public class CTWeatherWebService
    {
        public async static Task<WeatherInformation> GetWeather()
        {
            HttpClient http = new HttpClient();
            var ctWbService = await http.GetStringAsync("http://api.openweathermap.org/data/2.5/weather?q=Cape%20Town&APPID=f27a016865a3eed617a112811e03e4ba");

            
            var weather = JsonConvert.DeserializeObject<WeatherInfo>(ctWbService);

            /*   List<string> fullReport = new List<string>();

               for (int index = 0; index < weather.weather.Count; index++)
               {
                   fullReport.Add(weather.weather[index].description);
                   fullReport.Add(weather.weather[index].id.ToString());
                   fullReport.Add(weather.weather[index].main);
                   fullReport.Add(weather.name[index].ToString());
                   fullReport.Add(weather.timezone.ToString());
                   fullReport.Add(weather.coord.lat.ToString());

               }
               */
            WeatherInformation info = new WeatherInformation();
            info.Temperature = weather.main.temp;
            info.Humidity = weather.main.humidity;
            info.pressure = weather.main.pressure;
            info.name = weather.name;



           foreach (var n in weather.weather)
            {
                info.Weather = n.description;
               
            }


            return info;

            
       
            

        }
    }
}
