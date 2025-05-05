using System.ComponentModel;
using caca360;
using caca360.Services;

namespace caca360;

public class LoginViewModel : INotifyPropertyChanged
{
    private readonly ApiService _api;
    private readonly AuthService _auth;
    public Command LoginCommand { get; }

    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;

    public LoginViewModel(ApiService api, AuthService auth)
    {
        _api = api;
        _auth = auth;
        LoginCommand = new Command(async () => await Login());
    }

    private async Task Login()
    {
        var token = await _api.LoginAsync(Username, Password);
        _auth.SetToken(token);
        var window = Application.Current?.Windows.FirstOrDefault();
        if (window is not null)
            window.Page = new AppShell();
    }

    public event PropertyChangedEventHandler? PropertyChanged;
}