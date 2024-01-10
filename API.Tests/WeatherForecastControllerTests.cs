using Microsoft.Extensions.Logging.Abstractions;

namespace API.Controllers.v1.Tests
{
	[TestClass]
	public class WeatherForecastControllerTests
	{
		[TestMethod]
		public void GetShouldReturnListOfWeatherForecastObjects()
		{
			//Arrange
			var _logger = new NullLogger<WeatherForecastController>();
			var wfCtrl = new WeatherForecastController(_logger);

			//Act

			var result = wfCtrl.Get();

			//Assert
			var actualCount = result.Count();
			Assert.IsNotNull(result);
			Assert.AreNotEqual(0, actualCount);
		}
	}
}