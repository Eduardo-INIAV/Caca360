using Microsoft.Maui.Storage;
using Microsoft.Extensions.DependencyInjection;

namespace caca360;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();

        var token = Preferences.Default.Get("auth_token", string.Empty);

        if (string.IsNullOrEmpty(token))
        {
            var loginPage = MauiProgram.ServiceProvider.GetService<LoginPage>();
            MainPage = new NavigationPage(loginPage);
        }
        else
        {
            MainPage = new AppShell();
        }
    }
}