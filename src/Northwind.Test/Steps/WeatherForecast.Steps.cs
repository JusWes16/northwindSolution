using System;

using Xunit;
using Xunit.Gherkin.Quick;


using Northwind.Web.Services;
using Northwind.Web.Models;

namespace Northwind.Test.Features
{
	[FeatureFile("./Features/WeatherForecast.feature")]
	public sealed class WeatherForecastFeature : Feature
	{
		private IWeatherForecastService _weather = null;
		private WeatherForecast _forecast = null;
		private Exception _serviceException = null;
		private String _summary = null;

		[Given(@"the weather forecast")]
		public void The_weather_forecast()
		{
			_weather = new WeatherForecastService();
		}

		[When(@"I get the forecast for tomorrow")]
		public void I_get_the_forecast_for_tomorrow()
		{
			_forecast = _weather.ForecastFor(DateTime.Now.AddDays(1));
		}

		[Then(@"the forecast temperature F should be greater than (\d+)")]
		public void The_forecast_temperature_F_should_be_greater_than(int temperature)
		{
			Assert.True(_forecast.TemperatureF > temperature);
		}

		[When(@"I get the forecast for yesterday")]
		public void I_get_the_forecast_for_yesterday()
		{
            try
            {
				_forecast = _weather.ForecastFor(DateTime.Now.AddDays(-1));
			}
			catch (Exception ex)
            {
				_serviceException = ex;
            }
		}

		[Then(@"the service should throw an invalid argument exception")]
		public void The_service_should_throw_an_argument_exception()
		{
			Assert.IsType<ArgumentException>(_serviceException);
		}

		[When(@"the temperature is 70")]
		public void Temperature_is_70()
		{
			_summary = _weather.SummaryFor(21);
		}

		[Then(@"the forecast summary should be mild")]
		public void The_forecast_summary_should_mild()
		{
			Assert.True(_summary == "Mild");
		}
	}
}