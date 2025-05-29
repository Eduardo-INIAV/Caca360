using caca360.ViewModels;
using caca360.Services;

namespace caca360;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();
        MainPage = new ContentPage(); // Placeholder, será substituído após checagem
        CheckLoginStatusAsync();
    }


    private async void CheckLoginStatusAsync()
    {
        var token = await SecureStorage.GetAsync("auth_token");
        if (!string.IsNullOrEmpty(token))
        {
            MainPage = new AppShell();
        }
        else
        {
            var loginVm = new LoginViewModel(
                MauiProgram.ServiceProvider.GetRequiredService<AuthService>()
            );
            MainPage = new NavigationPage(new LoginPage(loginVm));
        }
    }
}
