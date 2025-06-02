using caca360.ViewModels;

namespace caca360;

public partial class UnguladosPage : ContentPage
{
    public UnguladosPage()
    {
        InitializeComponent();
        BindingContext = new UnguladosViewModel();
        Shell.SetBackButtonBehavior( this, new BackButtonBehavior { IsVisible = false });
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
    private void BackButtonBehavior()
    {
        // Faz a nUnguladosgação para a página desejada
        this.Dispatcher.Dispatch(async () =>
        {
            await Shell.Current.GoToAsync("//EspeciesPage");
        });
    }

    protected override bool OnBackButtonPressed()
    {
        // Faz a nUnguladosgação para a página desejada
        this.Dispatcher.Dispatch(async () =>
        {
            await Shell.Current.GoToAsync("//EspeciesPage");
        });

        // Retorna true para impedir o comportamento padrão (fechar a página atual)
        return true;
    }

}
