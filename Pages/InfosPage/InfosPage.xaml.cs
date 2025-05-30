namespace caca360;

public partial class InfosPage : ContentPage
{
    public InfosPage()
    {
        InitializeComponent();
        Shell.SetBackButtonBehavior(this, new BackButtonBehavior { IsVisible = true });
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
            await Shell.Current.GoToAsync("//MainPage");
        });
    
    }

    private void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (BindingContext is ViewModels.CategoriasViewModel vm &&
            e.CurrentSelection.Count > 0 &&
            e.CurrentSelection[0] is caca360.Models.Categoria categoria)
        {
            vm.CategoriaSelecionada = categoria;
        }

        // Limpar a seleção visual para permitir nova seleção
        ((CollectionView)sender).SelectedItem = null;
    }

    protected override bool OnBackButtonPressed()
    {
        Shell.Current.GoToAsync("//MainPage");
        return true;
    }


}
