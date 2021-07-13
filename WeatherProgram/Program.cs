﻿using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;

namespace WeatherProgram
{
    class Program
    {
        //POTENTIAL TODOS: further specification of location, alternative means of accessing "temp"
        static void Main(string[] args)
        {
            Console.WriteLine("What U.S. city do you need the current temperature (Fahrenheit) of?");

            var city = Console.ReadLine();

            var client = new HttpClient();
            var weatherURL = "https://api.openweathermap.org/data/2.5/weather?q=" + city + "&appid=15776b0352de8025d13304f01df507d6";

            var weatherResponse = client.GetStringAsync(weatherURL).Result;

            var weatherMain = JObject.Parse(weatherResponse).GetValue("main").ToString();

            var weatherTemp = double.Parse(JObject.Parse(weatherMain).GetValue("temp").ToString());

            Console.WriteLine("The current weather is approximately " + Math.Round((weatherTemp - 273.15) * 9 / 5 + 32) +
                " degrees Fahrenheit.");
        }
    }
}
