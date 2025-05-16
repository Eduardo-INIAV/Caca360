namespace caca360;

public partial class InfosPage : ContentPage
{
    public InfosPage()
    {
        InitializeComponent();
    }

    private void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (BindingContext is ViewModels.CategoriasViewModel vm &&
            e.CurrentSelection.Count > 0 &&
            e.CurrentSelection[0] is string categoria)
        {
            vm.CategoriaSelecionada = categoria;
        }

        // Limpar a seleção visual para permitir nova seleção
        ((CollectionView)sender).SelectedItem = null;
    }

}
