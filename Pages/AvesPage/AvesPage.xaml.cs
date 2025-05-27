using caca360.ViewModels;

namespace caca360;

public partial class AvesPage : ContentPage
{
    public AvesPage()
    {
        InitializeComponent();
        BindingContext = new AvesViewModel();
        Shell.SetBackButtonBehavior( this, new BackButtonBehavior { IsVisible = true });
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
        // Faz a navegação para a página desejada
        this.Dispatcher.Dispatch(async () =>
        {
            await Shell.Current.GoToAsync("//EspeciesPage");
        });
    }

    protected override bool OnBackButtonPressed()
    {
        // Faz a navegação para a página desejada
        this.Dispatcher.Dispatch(async () =>
        {
            await Shell.Current.GoToAsync("//EspeciesPage");
        });

        // Retorna true para impedir o comportamento padrão (fechar a página atual)
        return true;
    }

}
