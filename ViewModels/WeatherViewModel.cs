using System.Collections.ObjectModel;
using System.ComponentModel;
using caca360.Models;
using caca360.Services;

namespace caca360.ViewModels;

public partial class WeatherViewModel : INotifyPropertyChanged
{
    public ObservableCollection<WeatherData> Forecast { get; set; } = new();

    private string _locationName = string.Empty;

    private readonly WeatherService _weatherService = new();
    private readonly LocationService _locationService = new();

    public event PropertyChangedEventHandler? PropertyChanged;

    public string LocationName
    {
        get => _locationName;
        set
        {
            if (_locationName != value)
            {
                _locationName = value;
                OnPropertyChanged(nameof(LocationName));
            }
        }
    }

    protected void OnPropertyChanged(string propertyName) =>
    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));


    public async Task LoadCurrentWeatherAsync()
    {
        var location = await _locationService.GetCurrentLocationAsync();

        if (location == null)
            throw new Exception("Não foi possível obter a localização.");

        var forecastList = await _weatherService.Get5DayForecastAsync(location.Latitude, location.Longitude);
        var name = await _weatherService.GetLocationNameAsync(location.Latitude, location.Longitude);

        MainThread.BeginInvokeOnMainThread(() =>
        {
            Forecast.Clear();
            foreach (var item in forecastList)
                Forecast.Add(item);

            LocationName = name;
        });
    }

}
