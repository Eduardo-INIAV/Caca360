using caca360.ViewModels;

namespace caca360;
public partial class ArmasPage : ContentPage
{
    public ArmasPage()
    {
        InitializeComponent();
        BindingContext = new ArmasViewModel();
        Shell.SetBackButtonBehavior(this, new BackButtonBehavior { IsVisible = true });
    }
}
