using System.Windows.Input;

namespace caca360;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }
}

public class MainPageViewModel
{
    public ICommand NavigateToDashboardCommand { get; }
    public ICommand NavigateToAbateCommand { get; }
    public ICommand NavigateToCensosCommand { get; }

    public ICommand NavigateToProfileCommand { get; }

    public MainPageViewModel(ICommand navigateToProfileCommand)
    {
        NavigateToDashboardCommand = new Command(async () => await Shell.Current.GoToAsync("//Dashboard"));
        NavigateToAbateCommand = new Command(async () => await Shell.Current.GoToAsync("//Abate"));
        NavigateToCensosCommand = new Command(async () => await Shell.Current.GoToAsync("//Censos"));
        NavigateToProfileCommand = new Command(async () => await Shell.Current.GoToAsync("//Profile"));
        
    }
}
