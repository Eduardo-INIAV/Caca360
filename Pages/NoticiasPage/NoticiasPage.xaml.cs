using caca360.ViewModels;

namespace caca360;

public partial class NoticiasPage : ContentPage
{
    public NoticiasPage()
    {
        InitializeComponent();

        if (BindingContext is NoticiasViewModel vm)
            _ = vm.BuscarNoticiasAsync("Caça animal em portugal");
    }

    private async void OnBuscarClicked(object sender, EventArgs e)
    {
        if (BindingContext is NoticiasViewModel vm)
            await vm.BuscarNoticiasAsync("Caça animal em portugal");
    }

    private async void OnAbrirNoticia(object sender, EventArgs e)
    {
        if (sender is Button btn && btn.CommandParameter is string url)
            await Launcher.Default.OpenAsync(url);
    }
}
