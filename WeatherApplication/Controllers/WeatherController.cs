using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Web.Mvc;

public class WeatherController : Controller
{
    private WeatherService _weatherService;

    public WeatherController()
    {
        _weatherService = new WeatherService();
    }

    public async Task<ActionResult> Index(string city)
    {
        if (string.IsNullOrEmpty(city))
        {
            city = "Bursa"; 
        }

        var weather = await _weatherService.GetWeatherAsync(city);
        ViewBag.Weather = weather;
        ViewBag.City = city;

        return View();
    }
}
