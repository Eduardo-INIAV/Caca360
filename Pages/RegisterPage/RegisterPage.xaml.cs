using caca360.Services;
<<<<<<< HEAD

=======
>>>>>>> 4ff6a764e4d3966fc84785130374f8f948ede153
namespace caca360;

public partial class RegisterPage : ContentPage
{
<<<<<<< HEAD
    private readonly AuthService _authService;

    public RegisterPage(RegisterViewModel vm, AuthService authService)
    {
        InitializeComponent();
        BindingContext = vm;
        _authService = authService;
    }

=======
    public RegisterPage() => InitializeComponent();
>>>>>>> 4ff6a764e4d3966fc84785130374f8f948ede153
    private async void OnRegisterButtonClicked(object sender, EventArgs e)
    {
        var username = ((RegisterViewModel)BindingContext).Username;
        var email = ((RegisterViewModel)BindingContext).Email;
        var password = ((RegisterViewModel)BindingContext).Password;

        if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
        {
            await DisplayAlert("Erro", "Por favor, preencha todos os campos.", "OK");
            return;
        }

        try
        {
            // Registra o usuário no Firebase
            await _authService.RegisterUserAsync(username, email, password);
            await DisplayAlert("Sucesso", "Registro realizado com sucesso!", "OK");
            // Redirecionar para a página de login
            await Navigation.PopAsync();
        }
        catch (Exception ex)
        {
            await DisplayAlert("Erro", $"Falha no registro: {ex.Message}", "OK");
        }
    }
}