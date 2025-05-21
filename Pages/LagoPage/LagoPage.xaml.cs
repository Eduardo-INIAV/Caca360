using caca360.ViewModels;

namespace caca360;
public partial class LagoPage : ContentPage
{
    public LagoPage()
    {
        InitializeComponent();
        BindingContext = new LagoViewModel();
        Shell.SetBackButtonBehavior(this, new BackButtonBehavior { IsVisible = true });
    }

    protected override bool OnBackButtonPressed()
    {
        Shell.Current.GoToAsync("//EspeciePage");
        return true;
    }

}
