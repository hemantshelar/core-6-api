namespace API.Services
{
	public interface IWeatherService
	{
		List<GetWeatherDataResponse> GetWeatherData();
	}

	public class WeatherService(IHttpClientFactory _httpClientFactory,ILogger<WeatherService> _logger,) : IWeatherService
	{
        public WeatherService()
        {
            
        }
        public List<GetWeatherDataResponse> GetWeatherData()
		{
			throw new NotImplementedException();
		}
	}
	public class GetWeatherDataRequest
	{
        public int AggregateHours { get; set; }
        public string Location { get; set; }
    }
	public class GetWeatherDataResponse
	{
        public string Address { get; set; }
        public DateTime DateTime { get; set; }

    }
}
