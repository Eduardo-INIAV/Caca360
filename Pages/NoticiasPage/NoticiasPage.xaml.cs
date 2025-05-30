using caca360.ViewModels;

namespace caca360;

public partial class NoticiasPage : ContentPage
{
    public NoticiasPage()
    {
        InitializeComponent();
        Shell.SetBackButtonBehavior(this, new BackButtonBehavior { IsVisible = false });

        if (BindingContext is NoticiasViewModel vm)
            _ = vm.BuscarNoticiasAsync("caçadores em portugal");
        var backButton = new ToolbarItem
        {
            IconImageSource = "back_arrow.png",
            Priority = 0,
            Order = ToolbarItemOrder.Primary,
            Command = new Command(() =>
            {
                BackButtonBehavior();
            })
        };
        ToolbarItems.Add(backButton);
    }

    private void BackButtonBehavior()
    {
        // Faz a navegação para a página desejada
        this.Dispatcher.Dispatch(async () =>
        {
            await Shell.Current.GoToAsync("//InfosPage");
        });
    }
    

    private async void OnBuscarClicked(object sender, EventArgs e)
    {
        if (BindingContext is NoticiasViewModel vm)
            await vm.BuscarNoticiasAsync("caçadores em portugal");
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


