using caca360.ViewModels;

namespace caca360;
public partial class CaesPage : ContentPage
{
    public CaesPage()
    {
        InitializeComponent();
        BindingContext = new CaesViewModel();
    }
}
