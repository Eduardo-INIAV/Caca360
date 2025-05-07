using caca360.ViewModels;

namespace caca360;

public partial class RegisterPage : ContentPage
{
    public RegisterPage(RegisterViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm; // Define o ViewModel como o BindingContext
    }
}
