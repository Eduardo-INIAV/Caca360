using caca360.ViewModels;

namespace caca360;
public partial class InfosPage : ContentPage
{
    public InfosPage(InfosViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}

