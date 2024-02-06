namespace API.Models
{
	public class AppConfig
	{
        public WeatherAPIConfig WeatherAPIConfig { get; set; }
    }

	public class LogLevel
	{
		public string Default { get; set; }
		public string MicosoftAspNetCore { get; set; }
	}

	public class WeatherAPIConfig
	{
        public string EndPoint { get; set; }
        public string APIKey { get; set; }
    }
}
