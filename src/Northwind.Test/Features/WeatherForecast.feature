Feature: Get Weather Forecast
	 To get the weather forecast 

Scenario: Get the weather forecast tomorrow
	Given the weather forecast 
	When I get the forecast for tomorrow
	Then the forecast temperature F should be greater than 0

Scenario: Cannot forecast the past
	Given the weather forecast
	When I get the forecast for yesterday
	Then the service should throw an invalid argument exception

Scenario: Temperature is 70
	Given the weather forecast
	When the temperature is 70
	Then the forecast summary should be mild