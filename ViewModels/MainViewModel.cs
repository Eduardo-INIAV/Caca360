using System.Windows.Input;

namespace caca360.ViewModels;
public class MainViewModel
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
        NavigateToZonasCommand = new Command(async () => await Shell.Current.GoToAsync("//ZonasPage")); // Fixed
        NavigateToInfosCommand = new Command(async () => await Shell.Current.GoToAsync("//InfosPage"));
        LogoutCommand = new Command(async () => await Logout());
    }
    private static async Task Logout()
    {
        // Limpa o token de autenticação
        Preferences.Default.Remove("auth_token");

        // Redireciona para a página de login
        await Shell.Current.GoToAsync("//LoginPage");
    }
}

