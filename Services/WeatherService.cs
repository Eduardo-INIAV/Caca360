using System.Globalization;
using System.Net.Http;
using System.Text.Json;
using caca360.Models;

namespace caca360.Services;

public class WeatherService
{
    private readonly HttpClient _client = new();
    private readonly string _apiKey = "70ff05d29fd240cb879143017252705";

    public async Task<List<WeatherData>> Get5DayForecastAsync(double lat, double lon)
    {
        string url = $"https://api.weatherapi.com/v1/forecast.json?key={_apiKey}&q={lat},{lon}&days=5&lang=pt";

        var response = await _client.GetAsync(url);
        if (!response.IsSuccessStatusCode)
            throw new Exception($"Erro na API WeatherAPI: {response.StatusCode}");

        var json = await response.Content.ReadAsStringAsync();
        using var doc = JsonDocument.Parse(json);
        var forecastDays = doc.RootElement.GetProperty("forecast").GetProperty("forecastday");

        var list = new List<WeatherData>();

        foreach (var day in forecastDays.EnumerateArray())
        {
            var dayInfo = day.GetProperty("day");
            var condition = dayInfo.GetProperty("condition");

            list.Add(new WeatherData
            {
                ForecastDate = day.GetProperty("date").GetString() ?? "",
                TMin = dayInfo.GetProperty("mintemp_c").GetDouble(),
                TMax = dayInfo.GetProperty("maxtemp_c").GetDouble(),
                WeatherDescription = condition.GetProperty("text").GetString() ?? "",
                IconUrl = "https:" + condition.GetProperty("icon").GetString(),
                PrecipitaProb = (int)dayInfo.GetProperty("daily_chance_of_rain").GetDouble()
            });
        }

        return list;
    }

    public async Task<string> GetLocationNameAsync(double lat, double lon)
    {
        using var client = new HttpClient();
        string url = $"https://api.weatherapi.com/v1/current.json?key={_apiKey}&q={lat.ToString(CultureInfo.InvariantCulture)},{lon.ToString(CultureInfo.InvariantCulture)}";

        var response = await client.GetAsync(url);
        if (!response.IsSuccessStatusCode)
            throw new Exception($"Erro ao obter nome da localização: {response.StatusCode}");

        var json = await response.Content.ReadAsStringAsync();

        using var doc = JsonDocument.Parse(json);

        var location = doc.RootElement.GetProperty("location");

        string name = location.GetProperty("name").GetString() ?? "";
        string region = location.GetProperty("region").GetString() ?? "";
        string country = location.GetProperty("country").GetString() ?? "";

        return string.IsNullOrWhiteSpace(region) ? $"{name}, {country}" : $"{name}, {region}";
    }


    private class GeoCity
    {
        public string Name { get; set; } = "";
    }
}
