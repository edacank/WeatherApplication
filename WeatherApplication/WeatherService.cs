using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

public class WeatherService
{
    private static readonly HttpClient client = new HttpClient();
    private string apiKey = ""; //my API key

    public async Task<string> GetWeatherAsync(string city)
    {
        string url = $"http://api.openweathermap.org/data/2.5/weather?q={city}&appid={apiKey}&units=metric";
        var response = await client.GetStringAsync(url);

        // JSON response decomposition
        var weatherData = JObject.Parse(response);
        var temperature = weatherData["main"]["temp"].ToString();
        var description = weatherData["weather"][0]["description"].ToString();

        return $"Temperature: {temperature}°C, Description: {description}";
    }
}
