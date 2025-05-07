using Microsoft.Maui.Controls;

namespace caca360;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();
    }

    protected override Window CreateWindow(IActivationState? activationState)
    {
        // Recupera o token de autenticação armazenado localmente
        var token = Preferences.Default.Get("auth_token", string.Empty);

        if (string.IsNullOrEmpty(token))
        {
            // Redireciona para a página de login
            var loginPage = MauiProgram.ServiceProvider?.GetRequiredService<LoginPage>();
            return new Window(new NavigationPage(loginPage));
        }
        else
        {
            // Redireciona para a MainPage após o login
            var mainPage = MauiProgram.ServiceProvider?.GetRequiredService<MainPage>();
            return new Window(new NavigationPage(mainPage));
        }
    }
}
