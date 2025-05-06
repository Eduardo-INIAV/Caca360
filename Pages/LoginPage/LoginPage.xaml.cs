namespace caca360;

public partial class LoginPage : ContentPage
{
    public LoginPage(LoginViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
    private async void OnRegisterButtonClicked(object sender, EventArgs e)
        {
            var registerPage = MauiProgram.ServiceProvider.GetRequiredService<RegisterPage>();
            await Navigation.PushAsync(registerPage);
        }
}
