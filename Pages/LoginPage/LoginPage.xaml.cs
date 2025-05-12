using caca360.ViewModels;
using Firebase.Auth;

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
        if (MauiProgram.ServiceProvider == null)
        {
            await DisplayAlert("Erro", "O ServiceProvider não foi inicializado.", "OK");
            return;
        }

        var registerPage = MauiProgram.ServiceProvider.GetRequiredService<RegisterPage>();
        await Navigation.PushAsync(registerPage);
    }
}
