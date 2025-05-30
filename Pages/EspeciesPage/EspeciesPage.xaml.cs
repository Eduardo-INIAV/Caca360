namespace caca360;

public partial class EspeciesPage : ContentPage
{
    public EspeciesPage()
    {
        InitializeComponent();
        Shell.SetBackButtonBehavior(this, new BackButtonBehavior { IsVisible = false});
        var backButton = new ToolbarItem
        {
            Text = "Voltar",
            Priority = 0,
            Order = ToolbarItemOrder.Primary,
            Command = new Command(() =>
            {
                BackButtonBehavior();
            })
        };
        ToolbarItems.Add(backButton);
    }
    

    private void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (BindingContext is ViewModels.EspeciesViewModel vm &&
            e.CurrentSelection.Count > 0 &&
            e.CurrentSelection[0] is Models.Especies Especies)
        {
            vm.EspeciesSelecionada = Especies;
        }

        // Limpar a seleção visual para permitir nova seleção
        ((CollectionView)sender).SelectedItem = null;
    }



    private void BackButtonBehavior()
    {
        // Faz a navegação para a página desejada
        this.Dispatcher.Dispatch(async () =>
        {
            await Shell.Current.GoToAsync("//InfosPage");
        });
    }
    protected override bool OnBackButtonPressed()
    {
        // Faz a navegação para a página desejada
        this.Dispatcher.Dispatch(async () =>
        {
            await Shell.Current.GoToAsync("//InfosPage");
        });

        // Retorna true para impedir o comportamento padrão (fechar a página atual)
        return true;
    }

}
