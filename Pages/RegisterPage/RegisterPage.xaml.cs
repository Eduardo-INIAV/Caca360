using caca360.Services;
namespace caca360;

public partial class RegisterPage : ContentPage
{
    public RegisterPage()
    {
        InitializeComponent();
    }

    private async void OnRegisterButtonClicked(object sender, EventArgs e)
    {
        var username = UsernameEntry.Text;
        var email = EmailEntry.Text;
        var password = PasswordEntry.Text;

        if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
        {
            await DisplayAlert("Erro", "Todos os campos são obrigatórios.", "OK");
            return;
        }

        try
        {
            // Chama o AuthService para registrar o usuário
            var authService = MauiProgram.ServiceProvider.GetRequiredService<AuthService>();
            await authService.RegisterUserAsync(username, email, password);

            await DisplayAlert("Sucesso", "Usuário registrado com sucesso!", "OK");
            await Navigation.PopAsync(); // Volta para a página de login
        }
        catch (Exception ex)
        {
            await DisplayAlert("Erro", $"Falha ao registrar: {ex.Message}", "OK");
        }
    }
}