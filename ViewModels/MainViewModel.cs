using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;


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

    private static async Task Logout()
    {
        Preferences.Default.Remove("auth_token");
        await Shell.Current.GoToAsync("//LoginPage");
    }
}
