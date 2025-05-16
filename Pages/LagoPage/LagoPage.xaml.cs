using caca360.ViewModels;

namespace caca360;
public partial class LagoPage : ContentPage
{
    public LagoPage()
    {
        InitializeComponent();
        BindingContext = new LagoViewModel();
    }
}
