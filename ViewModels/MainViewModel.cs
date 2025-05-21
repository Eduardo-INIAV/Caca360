using System.Text.Json;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.ApplicationModel;

namespace caca360.ViewModels;

public partial class MainViewModel : ObservableObject
{
    public ICommand NavigateToDashboardCommand { get; }
    public ICommand NavigateToAbateCommand { get; }
    public ICommand NavigateToCensosCommand { get; }
    public ICommand NavigateToProfileCommand { get; }
    public ICommand NavigateToZonasCommand { get; }
    public ICommand NavigateToInfosCommand { get; }
    public ICommand LogoutCommand { get; }

    private string? _temperatura;
    public string? Temperatura
    {
        get => _temperatura;
        set => SetProperty(ref _temperatura, value);
    }

    private string? _descricao;
    public string? Descricao
    {
        get => _descricao;
        set => SetProperty(ref _descricao, value);
    }

    public MainViewModel()
    {
        NavigateToDashboardCommand = new Command(async () => await Shell.Current.GoToAsync("//Dashboard"));
        NavigateToAbateCommand = new Command(async () => await Shell.Current.GoToAsync("//Abate"));
        NavigateToCensosCommand = new Command(async () => await Shell.Current.GoToAsync("//Censos"));
        NavigateToProfileCommand = new Command(async () => await Shell.Current.GoToAsync("//ProfilePage"));
        NavigateToZonasCommand = new Command(async () => await Shell.Current.GoToAsync("//ZonasPage"));
        NavigateToInfosCommand = new Command(async () => await Shell.Current.GoToAsync("//InfosPage"));
        LogoutCommand = new Command(async () => await Logout());
    }

    [RelayCommand]
    public async Task BuscarTempoAsync()
    {
        try
        {
            var location = await Geolocation.Default.GetLocationAsync();
            if (location is null)
            {
                Temperatura = "Localização não encontrada";
                Descricao = "";
                return;
            }

            // Aqui você precisaria converter latitude/longitude para o código da cidade do IPMA.
            // Exemplo: var cityCode = await GetCityCodeFromCoordinates(location.Latitude, location.Longitude);

            // Por enquanto, ainda usa o código fixo:
            var url = "https://api.ipma.pt/open-data/forecast/meteorology/cities/daily/1110600.json";
            using var http = new HttpClient();
            var json = await http.GetStringAsync(url);

            using var doc = JsonDocument.Parse(json);
            var root = doc.RootElement;
            var data = root.GetProperty("data")[0];
            Temperatura = data.GetProperty("tMin").GetString() + "°C - " + data.GetProperty("tMax").GetString() + "°C";
            Descricao = data.GetProperty("predWindDir").GetString();
        }
        catch (Exception ex)
        {
            Temperatura = "Erro ao buscar dados";
            Descricao = ex.Message;
        }
    }


    private static async Task Logout()
    {
        Preferences.Default.Remove("auth_token");
        await Shell.Current.GoToAsync("//LoginPage");
    }
}
