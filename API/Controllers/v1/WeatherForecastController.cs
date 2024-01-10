using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.v1
{
	[ApiController]
	[ApiVersion("1.0")]
	[Route("api/v{version:apiVersion}/[controller]")]
	public class WeatherForecastController : ControllerBase
	{
		private readonly string _version = "1.0";
		private static readonly string[] Summaries = new[]
		{
			"Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
		};

		private readonly ILogger<WeatherForecastController> _logger;
		private readonly IHttpClientFactory _httpClientFactory;

		public WeatherForecastController(ILogger<WeatherForecastController> logger, IHttpClientFactory httpClientFactory)
		{
			_logger = logger;
			_httpClientFactory = httpClientFactory;
		}

		[HttpGet(Name = "GetWeatherForecast")]
		public IEnumerable<WeatherForecast> GetWeatherForecast()
		{
			return Enumerable.Range(1, 5).Select(index => new WeatherForecast
			{
				Date = DateTime.Now.AddDays(index),
				TemperatureC = Random.Shared.Next(-20, 55),
				Summary = Summaries[Random.Shared.Next(Summaries.Length)],
				Version = _version
			})
			.ToArray();
		}


		[HttpGet("{cityName}",Name = "GetWeatherByCityName")]
		public async Task<IActionResult> GetWeatherByCityName(string cityName)
		{
			var httpClient = _httpClientFactory.CreateClient();

			var uri = new Uri("https://visual-crossing-weather.p.rapidapi.com/forecast?aggregateHours=24&location=Washington%2CDC%2CUSA&contentType=csv&unitGroup=us&shortColumnNames=0");
			
			var result = await httpClient.GetAsync(uri);

			var responseAsString = await result.Content.ReadAsStringAsync();
			return Ok(responseAsString);



		}
	}
}
