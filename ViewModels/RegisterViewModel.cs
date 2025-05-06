using System.ComponentModel;
using System.Windows.Input;
using caca360.Services;

namespace caca360;

public class RegisterViewModel : INotifyPropertyChanged
{
    private readonly AuthService _authService;
    private string _username = string.Empty; // Inicializado para evitar nulidade
    private string _email = string.Empty;    // Inicializado para evitar nulidade
    private string _password = string.Empty;

    public event PropertyChangedEventHandler? PropertyChanged;

    public string Username
    {
        get => _username;
        set
        {
            _username = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Username)));
        }
    }

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

    public ICommand RegisterCommand { get; }

    public RegisterViewModel(AuthService authService)
    {
        _authService = authService;
        RegisterCommand = new Command(async () => await Register());
    }

    private async Task Register()
    {
        if (string.IsNullOrEmpty(Username) || string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(Password))
        {
            await App.Current.MainPage.DisplayAlert("Erro", "Por favor, preencha todos os campos.", "OK");
            return;
        }

        try
        {
            await _authService.RegisterUserAsync(Username, Email, Password);
            await App.Current.MainPage.DisplayAlert("Sucesso", "Registro realizado com sucesso!", "OK");
            // Redirecionar para a página de login
            await Shell.Current.GoToAsync("..");
        }
        catch (Exception ex)
        {
            await App.Current.MainPage.DisplayAlert("Erro", $"Falha no registro: {ex.Message}", "OK");
        }
    }
}
