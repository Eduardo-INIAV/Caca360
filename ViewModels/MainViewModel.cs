using System.Windows.Input;

namespace caca360;
public class MainViewModel
{
    public ICommand NavigateToDashboardCommand { get; }
    public ICommand NavigateToAbateCommand { get; }
    public ICommand NavigateToCensosCommand { get; }
    public ICommand NavigateToProfileCommand { get; }

    public MainViewModel()
    {
        NavigateToDashboardCommand = new Command(async () => await Shell.Current.GoToAsync("//Dashboard"));
        NavigateToAbateCommand = new Command(async () => await Shell.Current.GoToAsync("//Abate"));
        NavigateToCensosCommand = new Command(async () => await Shell.Current.GoToAsync("//Censos"));
        NavigateToProfileCommand = new Command(async () => await Shell.Current.GoToAsync("//ProfilePage"));
    }
}

