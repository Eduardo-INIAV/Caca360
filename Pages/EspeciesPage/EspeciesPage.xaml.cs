namespace caca360;

public partial class EspeciesPage : ContentPage
{
    public EspeciesPage()
    {
        InitializeComponent();
        Shell.SetBackButtonBehavior(this, new BackButtonBehavior { IsVisible = true });
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
    protected override bool OnBackButtonPressed()
    {
        Shell.Current.GoToAsync("//InfosPage");
        return true;
    }

}
