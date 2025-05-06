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
            await DisplayAlert("Erro", "Todos os campos s�o obrigat�rios.", "OK");
            return;
        }

        try
        {
            // Chama o AuthService para registrar o usu�rio
            var authService = MauiProgram.ServiceProvider.GetRequiredService<AuthService>();
            await authService.RegisterUserAsync(username, email, password);

            await DisplayAlert("Sucesso", "Usu�rio registrado com sucesso!", "OK");
            await Navigation.PopAsync(); // Volta para a p�gina de login
        }
        catch (Exception ex)
        {
            await DisplayAlert("Erro", $"Falha ao registrar: {ex.Message}", "OK");
        }
    }
}