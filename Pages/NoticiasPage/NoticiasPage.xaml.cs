using caca360.ViewModels;

namespace caca360;

public partial class NoticiasPage : ContentPage
{
    private readonly NoticiasViewModel viewModel = new();

    public NoticiasPage()
    {
        InitializeComponent();

        BindingContext = viewModel;

        Shell.SetBackButtonBehavior(this, new BackButtonBehavior { IsVisible = false });

        // Carrega as notícias ao abrir a página
        _ = viewModel.BuscarNoticiasAsync("caçadores portugal");

        var backButton = new ToolbarItem
        {
            Text = "Voltar",
            Priority = 0,
            Order = ToolbarItemOrder.Primary,
            Command = new Command(BackButtonBehavior)
        };
        ToolbarItems.Add(backButton);
    }

    private void BackButtonBehavior()
    {
        // Navega para a página desejada
        Dispatcher.Dispatch(async () =>
        {
            await Shell.Current.GoToAsync("//InfosPage");
        });
    }

    private async void OnBuscarClicked(object sender, EventArgs e)
    {
        await viewModel.BuscarNoticiasAsync("caçadores portugal");
    }

    private async void OnAbrirNoticia(object sender, EventArgs e)
    {
        if (sender is Button btn && btn.CommandParameter is string url)
            await Launcher.Default.OpenAsync(url);
    }

    protected override bool OnBackButtonPressed()
    {
        Shell.Current.GoToAsync("//InfosPage");
        return true;
    }
}
