namespace LiveWeather.Models;
public class WeatherResponse
{
    public required Location Location { get; set; }
    public required Current Current { get; set; }
}

