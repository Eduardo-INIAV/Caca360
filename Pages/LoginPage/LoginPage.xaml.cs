using caca360.Services;
namespace caca360;

public partial class LoginPage : ContentPage
{
    private readonly AuthService _authService;

    public LoginPage(LoginViewModel vm, AuthService authService)
    {
        InitializeComponent();
        BindingContext = vm;
        _authService = authService;
    }
<<<<<<< HEAD

    private async void OnLoginButtonClicked(object sender, EventArgs e)
    {
        var username = ((LoginViewModel)BindingContext).Username;
        var password = ((LoginViewModel)BindingContext).Password;

        if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
        {
            await DisplayAlert("Erro", "Por favor, preencha todos os campos.", "OK");
            return;
        }

        try
        {
            // Autentica o usuário com Firebase
            var token = await _authService.LoginAsync(username, password);
            await DisplayAlert("Sucesso", "Login realizado com sucesso!", "OK");
        }
        catch (Exception ex)
        {
            await DisplayAlert("Erro", $"Falha no login: {ex.Message}", "OK");
        }
    }

    private async void OnRegisterButtonClicked(object sender, EventArgs e)
    {
        var registerPage = MauiProgram.ServiceProvider.GetRequiredService<RegisterPage>();
        await Navigation.PushAsync(registerPage);
    }
}
=======
    private async void OnRegisterButtonClicked(object sender, EventArgs e)
        {
            var registerPage = MauiProgram.ServiceProvider.GetRequiredService<RegisterPage>();
            await Navigation.PushAsync(registerPage);
        }
}
>>>>>>> 4ff6a764e4d3966fc84785130374f8f948ede153
