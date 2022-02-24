using System;
using Northwind.Web.Models;

namespace Northwind.Web.Services
{
	public interface IWeatherForecastService
	{
		WeatherForecast ForecastFor(DateTime dateTime);

		string SummaryFor(int temperature);
	}


	public class WeatherForecastService : IWeatherForecastService
	{
		private static readonly string[] Summaries = new[]
		{
				"Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
		};

		public WeatherForecast ForecastFor(DateTime dateTime)
		{
			if (dateTime < DateTime.Now) 
				throw new ArgumentException("Invalid datetime");

			var rng = new Random();
			var temperatureC = rng.Next(-20, 55);
			return new WeatherForecast
			{
				Date = dateTime,
				TemperatureC = temperatureC,
				Summary = SummaryFor(temperatureC)
			};
		}

		public string SummaryFor(int temperature)
		{
			temperature = 32 + (int)(temperature / 0.5556);
			//var rng = new Random();
			//return Summaries[rng.Next(Summaries.Length)];

			switch (temperature)
            {
				case <= 0:
					return Summaries[0]; // Freezing
				case <= 30:
					return Summaries[1]; // Bracing
				case <= 40:
					return Summaries[2]; // Chilly
				case <= 50:
					return Summaries[3]; // Cool
				case <= 70:
					return Summaries[4]; // Mild
				case <= 80:
					return Summaries[5]; // Warm
				case <= 90:
					return Summaries[6]; // Balmy
				case <= 100:
					return Summaries[7]; // Hot
				case <= 110:
					return Summaries[8]; // Sweltering
				default:
					return Summaries[9]; // Scorching
			}
		}
	}

}