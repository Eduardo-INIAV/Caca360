using caca360.ViewModels;

namespace caca360;
public partial class CaesPage : ContentPage
{
    public CaesPage()
    {
        InitializeComponent();
        BindingContext = new CaesViewModel();
        Shell.SetBackButtonBehavior(this, new BackButtonBehavior { IsVisible = false });
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
            await Shell.Current.GoToAsync("//InfosPage");
        });
    
    }

    protected override bool OnBackButtonPressed()
    {
        Shell.Current.GoToAsync("//InfosPage");
        return true;
    }

}
