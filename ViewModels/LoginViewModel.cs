using System.ComponentModel;
using System.Windows.Input;
using caca360.Services;

namespace caca360.ViewModels;

public partial class LoginViewModel : INotifyPropertyChanged
{
    private readonly AuthService _authService;
    private string _email = string.Empty;
    private string _password = string.Empty;

    public event PropertyChangedEventHandler? PropertyChanged;
    public ICommand ChangePasswordCommand { get; }

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
        ChangePasswordCommand = new Command(async () => await OnChangePasswordAsync());
    }

    private async Task Login()
    {
        try
        {
            if (string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(Password))
            {
                await App.Current.MainPage.DisplayAlert("Erro", "Por favor, preencha todos os campos.", "OK");
                return;
            }

            var token = await _authService.LoginAsync(Email, Password);
            if (string.IsNullOrEmpty(token))
            {
                throw new Exception("Token inválido.");
            }

            await App.Current.MainPage.DisplayAlert("Sucesso", "Login realizado com sucesso!", "OK");
            await Shell.Current.GoToAsync("//MainPage");
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine($"Erro no login: {ex}");
            await App.Current.MainPage.DisplayAlert("Erro", $"Falha no login: {ex.Message}", "OK");
        }
    }
    private async Task OnChangePasswordAsync()
    {
        try
        {
            if (string.IsNullOrWhiteSpace(Email))
            {
                await App.Current.MainPage.DisplayAlert("Erro", "Por favor, insira um email válido.", "OK");
                return;
            }

            // Chame aqui o serviço para enviar o email de redefinição de senha
            // Exemplo fictício:
            // await _authService.SendPasswordResetEmailAsync(Email);

            await App.Current.MainPage.DisplayAlert("Sucesso", "Um email de redefinição de palavra-passe foi enviado.", "OK");
        }
        catch (Exception)
        {
            await App.Current.MainPage.DisplayAlert("Erro", "Não foi possível enviar o email de redefinição.", "OK");
        }
    }
}

