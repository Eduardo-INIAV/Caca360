using caca360.ViewModels;

namespace caca360;

public partial class ProfilePage : ContentPage
{
    public ProfilePage()
    {
        InitializeComponent();
        BindingContext = new ProfileViewModel();
        Shell.SetBackButtonBehavior(this, new BackButtonBehavior { IsVisible = true });
    }

    protected override bool OnBackButtonPressed()
    {
        Shell.Current.GoToAsync("//MainPage");
        return true;
    }
}
