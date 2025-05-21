using caca360.ViewModels;

namespace caca360;
public partial class MamiferosPage : ContentPage
{
    public MamiferosPage()
    {
        InitializeComponent();
        BindingContext = new MamiferosViewModel();
        Shell.SetBackButtonBehavior(this, new BackButtonBehavior { IsVisible = true });
    }
}
