using caca360.ViewModels;

namespace caca360;
public partial class AvesPage : ContentPage
{
    public AvesPage()
    {
        InitializeComponent();
        BindingContext = new AvesViewModel();
        Shell.SetBackButtonBehavior(this, new BackButtonBehavior { IsVisible = true });
    }
}
