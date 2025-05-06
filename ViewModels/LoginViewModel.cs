using System.ComponentModel;
using System.Windows.Input;
using caca360.Services;

namespace caca360;

public class LoginViewModel : INotifyPropertyChanged
{
    private readonly AuthService _authService;
    private string _email = string.Empty; // Inicializado para evitar nulidade
    private string _password = string.Empty; // Inicializado para evitar nulidade

    public event PropertyChangedEventHandler? PropertyChanged;

    public string Email
    {
        get => _email;
        set
        {
            _email = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Email)));
        }
    }

    public string Password
    {
        get => _password;
        set
        {
            _password = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Password)));
        }
    }

    public ICommand LoginCommand { get; }

    public LoginViewModel(AuthService authService)
    {
        _authService = authService;
        LoginCommand = new Command(async () => await Login());
    }

    private async Task Login()
    {
        if (string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(Password))
        {
            await App.Current.MainPage.DisplayAlert("Erro", "Por favor, preencha todos os campos.", "OK");
            return;
        }

        try
        {
            var token = await _authService.LoginAsync(Email, Password);
            await App.Current.MainPage.DisplayAlert("Sucesso", "Login realizado com sucesso!", "OK");
            // Redirecionar para a página principal
            await Shell.Current.GoToAsync("//MainPage");
        }
        catch (Exception ex)
        {
            await App.Current.MainPage.DisplayAlert("Erro", $"Falha no login: {ex.Message}", "OK");
        }
    }
}
