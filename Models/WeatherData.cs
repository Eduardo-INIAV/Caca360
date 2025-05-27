namespace caca360.Models;

public class WeatherData
{
    public string? ForecastDate { get; set; }
    public double TMin { get; set; }
    public double TMax { get; set; }
    public string? WeatherDescription { get; set; }
    public string? IconUrl { get; set; }
    public int PrecipitaProb { get; set; } // não fornecido diretamente, pode ser 0 ou calculado mais tarde
}
