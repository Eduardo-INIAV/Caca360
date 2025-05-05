using Microsoft.Maui.Storage;
using Microsoft.Extensions.DependencyInjection;

namespace caca360;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();

        // Recupera o token de autenticação armazenado localmente
        var token = Preferences.Default.Get("auth_token", string.Empty);

        // Verifica se o token está vazio ou inválido
        if (string.IsNullOrEmpty(token))
        {
            // Redireciona para a página de login
            var loginPage = MauiProgram.ServiceProvider.GetRequiredService<LoginPage>();
            MainPage = new NavigationPage(loginPage);
        }
        else
        {
            // Redireciona para a página principal (AppShell)
            MainPage = new AppShell();
        }
    }
} 