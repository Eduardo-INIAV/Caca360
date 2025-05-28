using caca360.ViewModels;

namespace caca360;

public partial class RegisterPage : ContentPage
{
    public RegisterPage(RegisterViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
        Shell.SetBackButtonBehavior(this, new BackButtonBehavior { IsVisible = true });
    }
}
