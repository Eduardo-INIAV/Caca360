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

    private async void OnLoginButtonClicked(object sender, EventArgs e)
    {
        var email = ((LoginViewModel)BindingContext).Email;
        var password = ((LoginViewModel)BindingContext).Password;

        if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
        {
            await DisplayAlert("Erro", "Por favor, preencha todos os campos.", "OK");
            return;
        }

        try
        {
            // Autentica o usuário com Firebase
            var token = await _authService.LoginAsync(email, password);
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
